using Microsoft.EntityFrameworkCore;
using Shoppa.Data.Models;

namespace Shoppa.Logic;

public class CartItemFlat
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class DomainLogic
{
    private readonly string connectionString;

    public DomainLogic(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // CUSTOMER METHODS
    // ดูสินค้าทั้งหมด
    public List<Product> GetAllProducts()
    {
        using var context = new EcommerceDbContext(connectionString);
        return context.Products
            .OrderBy(p => p.ProductId)
            .ToList();
    }

    // Checkout / Create Order
    public int Checkout(List<CartItemFlat> items)
    {
        using var context = new EcommerceDbContext(connectionString);
        using var transaction = context.Database.BeginTransaction();

        Order order = new Order
        {
            OrderDate = DateTime.Now,
            PaymentStatus = "Unpaid",
            ShippingStatus = "Not Shipping",
            OrderStatus = "Pending",
            TotalPrice = 0
        };

        decimal total = 0;
        foreach (var item in items)
        {
            var product = context.Products.Single(p => p.ProductId == item.ProductId);
            if (product.Stock < item.Quantity)
            {
                throw new Exception($"Product '{product.ProductName}' stock not enough.");
            }

            product.Stock -= item.Quantity;
            Orderitem orderItem = new Orderitem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = product.Price
            };
            order.Orderitems.Add(orderItem);
            total += product.Price * item.Quantity;
        }

        order.TotalPrice = total;
        context.Orders.Add(order);
        context.SaveChanges();

        transaction.Commit();
        return order.OrderId;
    }

    // อัปเดตสถานะการชำระเงิน (ย้ายมาจาก Controller เพื่อรองรับ WinForms)
    public void UpdatePaymentStatus(int orderId, string paymentStatus, string orderStatus)
    {
        using var context = new EcommerceDbContext(connectionString);
        var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order == null)
            throw new KeyNotFoundException("Order not found");

        order.PaymentStatus = paymentStatus;
        order.OrderStatus = orderStatus;

        context.SaveChanges();
    }

    // ดูรายการ order ของ customer
    public List<Order> GetAllOrders()
    {
        using var context = new EcommerceDbContext(connectionString);
        return context.Orders
            .Include(o => o.Orderitems)
            .ThenInclude(i => i.Product)
            .OrderByDescending(o => o.OrderId)
            .ToList();
    }

    // ดูรายละเอียด order
    public Order GetOrder(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);
        return context.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Orderitems)
            .ThenInclude(i => i.Product)
            .Single();
    }


    // SELLER METHODS
    // ดึงข้อมูลสำหรับหน้า Seller
    public List<Order> GetSellerOrders()
    {
        using var context = new EcommerceDbContext(connectionString);
        return context.Orders
            .AsNoTracking()
            .Include(o => o.Orderitems)
                .ThenInclude(oi => oi.Product)
            .Where(o => o.PaymentStatus == "Paid"
                     && o.ShippingStatus == "Not Shipping"
                     && o.OrderStatus == "Confirmed")
            .ToList();
    }

    // Seller กดยืนยันออเดอร์เพื่อเตรียมส่ง
    public Order ConfirmShippingBySeller(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);
        var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order == null)
            throw new KeyNotFoundException("ไม่พบคำสั่งซื้อ");

        order.OrderStatus = "Shipping";
        order.ShippingStatus = "Pending";

        context.SaveChanges();
        return order;
    }

    // DELIVERY STAFF METHODS
    // ดูรายการจัดส่งสำหรับ Delivery Staff ทั้งหมด
    public List<Order> GetDeliveryOrders()
    {
        using var context = new EcommerceDbContext(connectionString);
        return context.Orders
            .AsNoTracking()
            .Include(o => o.Orderitems)
                .ThenInclude(oi => oi.Product)
            .Where(o => o.OrderStatus == "Shipping" || o.OrderStatus == "Delivery")
            .OrderBy(o => o.OrderId)
            .ToList();
    }

    // อัปเดตสถานะ
    public Order UpdateDeliveryAndOrderStatus(int orderId, string rawShippingStatus)
    {
        using var context = new EcommerceDbContext(connectionString);
        var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order == null)
            throw new KeyNotFoundException("Order not found");

        var shippingStatus = rawShippingStatus.Trim().ToLower();
        order.ShippingStatus = rawShippingStatus;

        switch (shippingStatus)
        {
            case "pending":
                order.OrderStatus = "Shipping";
                break;
            case "shipping":
                order.OrderStatus = "Delivery";
                break;
            case "completed":
                order.OrderStatus = "Completed";
                break;
            default:
                throw new ArgumentException("Invalid ShippingStatus");
        }

        context.SaveChanges();
        return order;
    }
}
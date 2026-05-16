using Microsoft.EntityFrameworkCore;
using Shoppa.Data.Models;

namespace Shoppa.Logic;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Shipping,
    Delivered,
    Completed
}

public class CartItemFlat
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class DomainLogic
{
    string connectionString;

    public DomainLogic(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // =====================================================
    // CUSTOMER
    // =====================================================

    // ดูสินค้าทั้งหมด
    public List<Product> GetAllProducts()
    {
        using var context = new EcommerceDbContext(connectionString);

        return context.Products
            .OrderBy(p => p.ProductId)
            .ToList();
    }

    // ค้นหาสินค้า
    public List<Product> SearchProducts(string keyword)
    {
        using var context = new EcommerceDbContext(connectionString);

        return context.Products
            .Where(p => p.ProductName.Contains(keyword))
            .OrderBy(p => p.ProductName)
            .ToList();
    }

    // Checkout / Create Order
    public int Checkout(List<CartItemFlat> items) // เปลี่ยนจาก void เป็น int
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
        context.SaveChanges(); // หลังเซฟตรงนี้ order.OrderId จะได้ค่ามาจาก Database ทันที

        transaction.Commit();

        return order.OrderId; // <--- เพิ่มบรรทัดนี้ เพื่อส่งเลข Order กลับไป
    }

    // ชำระเงิน
    public void Payment(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);

        var order = context.Orders
            .Single(o => o.OrderId == orderId);

        if (order.PaymentStatus != "Unpaid")
        {
            throw new Exception("Order already paid.");
        }

        order.PaymentStatus = "Paid";
        order.OrderStatus = "Confirmed";

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

    // =====================================================
    // SELLER
    // =====================================================

    // Seller จัดส่งสินค้า
    public void ShipOrder(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);

        var order = context.Orders
            .Single(o => o.OrderId == orderId);

        if (order.OrderStatus != "Confirmed")
        {
            throw new Exception("Cannot ship order.");
        }

        order.OrderStatus = "Shipping";
        order.ShippingStatus = "Shipping";

        context.SaveChanges();
    }

    // Seller จัดการสินค้า
    public void AddProduct(Product product)
    {
        using var context = new EcommerceDbContext(connectionString);

        context.Products.Add(product);

        context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        using var context = new EcommerceDbContext(connectionString);

        context.Products.Update(product);

        context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        using var context = new EcommerceDbContext(connectionString);

        var product = context.Products
            .Single(p => p.ProductId == productId);

        context.Products.Remove(product);

        context.SaveChanges();
    }

    // =====================================================
    // DELIVERY STAFF
    // =====================================================

    // ดูรายการจัดส่ง
    public List<Order> GetShippingOrders()
    {
        using var context = new EcommerceDbContext(connectionString);

        return context.Orders
            .Where(o => o.OrderStatus == "Shipping")
            .Include(o => o.Orderitems)
            .ThenInclude(i => i.Product)
            .ToList();
    }

    // Update delivery status
    public void UpdateDeliveryStatus(
        int orderId,
        string shippingStatus)
    {
        using var context = new EcommerceDbContext(connectionString);

        var order = context.Orders
            .Single(o => o.OrderId == orderId);

        if (order.OrderStatus != "Shipping")
        {
            throw new Exception(
                "Cannot update delivery status."
            );
        }

        order.ShippingStatus = shippingStatus;

        context.SaveChanges();
    }

    // Confirm delivery
    public void ConfirmDelivery(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);

        var order = context.Orders
            .Single(o => o.OrderId == orderId);

        if (order.OrderStatus != "Shipping")
        {
            throw new Exception(
                "Cannot confirm delivery."
            );
        }

        order.OrderStatus = "Delivery";
        order.ShippingStatus = "Delivery";

        context.SaveChanges();
    }

    // Complete order
    public void CompleteOrder(int orderId)
    {
        using var context = new EcommerceDbContext(connectionString);

        var order = context.Orders
            .Single(o => o.OrderId == orderId);

        if (order.OrderStatus != "Delivery")
        {
            throw new Exception(
                "Cannot complete order."
            );
        }

        order.OrderStatus = "Completed";
        order.ShippingStatus = "Completed";

        context.SaveChanges();
    }
}
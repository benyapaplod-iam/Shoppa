using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppa.Data.Models;
using Shoppa.Logic;


namespace Shoppa.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    // GET ALL: api/v1/order
    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        try
        {
            var domain = new DomainLogic(MyConfig.ConnStr);
            var orders = domain.GetAllOrders();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET SINGLE: api/v1/order/5
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        try
        {
            var domain = new DomainLogic(MyConfig.ConnStr);
            var order = domain.GetOrder(id);

            if (order == null) return NotFound();

            return Ok(order);
        }
        catch (InvalidOperationException) 
        {
            return NotFound(new { message = $"Order {id} not found." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // สร้าง Order ใหม่ (Checkout)
    [HttpPost("checkout")]
    public ActionResult Checkout([FromBody] List<CartItemFlat> items)
    {
        try
        {
            var domain = new DomainLogic(MyConfig.ConnStr);
            int newOrderId = domain.Checkout(items);
            return Ok(new { orderId = newOrderId, message = "Order created successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    public class UpdateShippingStatusRequest
    {
        public required string ShippingStatus { get; set; }
    }

    // UPDATE ORDER STATUS ของ dalivery (ShippingStatus + OrderStatus)
    [HttpPut("{id}/status")]
    public ActionResult UpdateStatus(int id, [FromBody] UpdateShippingStatusRequest req)
    {
        try
        {
            if (req == null || string.IsNullOrWhiteSpace(req.ShippingStatus))
                return BadRequest(new { message = "ShippingStatus is required" });

            using var db = new EcommerceDbContext();

            var order = db.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            var shippingStatus = req.ShippingStatus.Trim().ToLower();

            order.ShippingStatus = req.ShippingStatus;

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
                    return BadRequest(new { message = "Invalid ShippingStatus" });
            }

            db.SaveChanges();

            return Ok(new
            {
                message = "Updated successfully",
                shipping = order.ShippingStatus,
                order = order.OrderStatus
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // อัปเดตสถานะการชำระเงินจาก WinForms เมื่อผู้ใช้กดปุ่ม "ชำระเงินสำเร็จ" (PaymentStatus = "Paid", OrderStatus = "Confirmed")
    [HttpPost("update-status")]
    public ActionResult UpdatePaymentStatus([FromBody] PaymentUpdateRequest req)
    {
        try
        {
            using var db = new EcommerceDbContext(); 
            var order = db.Orders.FirstOrDefault(o => o.OrderId == req.OrderId);

            if (order == null) return NotFound(new { message = "Order not found" });

            order.PaymentStatus = req.PaymentStatus; 
            order.OrderStatus = req.OrderStatus;     

            db.SaveChanges();
            return Ok(new { message = "Payment updated successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // อัปเดตสถานะการจัดส่งเป็น "Shipping" และ ShippingStatus เป็น "Pending" เมื่อ Seller กดปุ่ม "ยืนยันออเดอร์"
    [HttpPut("{id}/confirm-shipping")]
    public ActionResult ConfirmShipping(int id)
    {
        try
        {
            using var db = new EcommerceDbContext();
            var order = db.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null) return NotFound(new { message = "ไม่พบคำสั่งซื้อ" });

  
            order.OrderStatus = "Shipping";      
            order.ShippingStatus = "Pending";    

            db.SaveChanges();

            return Ok(new
            {
                message = "ยืนยันออเดอร์สำเร็จ",
                orderId = id,
                orderStatus = order.OrderStatus,
                shippingStatus = order.ShippingStatus
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    // ดึงข้อมูลสำหรับหน้า Seller 
    [HttpGet("seller-orders")]
    public ActionResult GetSellerOrders()
    {
        try
        {
            using var db = new EcommerceDbContext();

            var orders = db.Orders
            .AsNoTracking()
            .Include(o => o.Orderitems)              
                .ThenInclude(oi => oi.Product)       
            .Where(o => o.PaymentStatus == "Paid"
                     && o.ShippingStatus == "Not Shipping"
                     && o.OrderStatus == "Confirmed")
            .ToList();

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET: api/v1/order/delivery-orders
    [HttpGet("delivery-orders")]
    public ActionResult<List<Order>> GetDeliveryOrders()
    {
        try
        {
            using var db = new EcommerceDbContext();


            var orders = db.Orders
                .AsNoTracking()
                .Include(o => o.Orderitems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.OrderStatus == "Shipping" || o.OrderStatus == "Delivery")
                .OrderBy(o => o.OrderId)
                .ToList();

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    public class PaymentUpdateRequest
    {
        public int OrderId { get; set; }
        public required string PaymentStatus { get; set; }
        public required string OrderStatus { get; set; }
    }
}
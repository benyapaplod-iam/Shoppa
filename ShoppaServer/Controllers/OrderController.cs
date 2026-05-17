using Microsoft.AspNetCore.Mvc;
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

    // UPDATE ORDER STATUS ของ delivery (ShippingStatus + OrderStatus)
    [HttpPut("{id}/status")]
    public ActionResult UpdateStatus(int id, [FromBody] UpdateShippingStatusRequest req)
    {
        try
        {
            if (req == null || string.IsNullOrWhiteSpace(req.ShippingStatus))
                return BadRequest(new { message = "ShippingStatus is required" });

            var domain = new DomainLogic(MyConfig.ConnStr);
            var updatedOrder = domain.UpdateDeliveryAndOrderStatus(id, req.ShippingStatus);

            return Ok(new
            {
                message = "Updated successfully",
                shipping = updatedOrder.ShippingStatus,
                order = updatedOrder.OrderStatus
            });
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // อัปเดตสถานะการชำระเงินจาก WinForms เมื่อผู้ใช้กดปุ่ม "ชำระเงินสำเร็จ"
    [HttpPost("update-status")]
    public ActionResult UpdatePaymentStatus([FromBody] PaymentUpdateRequest req)
    {
        try
        {
            var domain = new DomainLogic(MyConfig.ConnStr);
            domain.UpdatePaymentStatus(req.OrderId, req.PaymentStatus, req.OrderStatus);

            return Ok(new { message = "Payment updated successfully" });
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = "Order not found" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // อัปเดตสถานะการจัดส่งเมื่อ Seller กดปุ่ม "ยืนยันออเดอร์"
    [HttpPut("{id}/confirm-shipping")]
    public ActionResult ConfirmShipping(int id)
    {
        try
        {
            var domain = new DomainLogic(MyConfig.ConnStr);
            var order = domain.ConfirmShippingBySeller(id);

            return Ok(new
            {
                message = "ยืนยันออเดอร์สำเร็จ",
                orderId = id,
                orderStatus = order.OrderStatus,
                shippingStatus = order.ShippingStatus
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
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
            var domain = new DomainLogic(MyConfig.ConnStr);
            var orders = domain.GetSellerOrders();
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
            var domain = new DomainLogic(MyConfig.ConnStr);
            var orders = domain.GetDeliveryOrders();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // DTO คลาสที่ใช้รับ Request
    public class UpdateShippingStatusRequest
    {
        public required string ShippingStatus { get; set; }
    }

    public class PaymentUpdateRequest
    {
        public int OrderId { get; set; }
        public required string PaymentStatus { get; set; }
        public required string OrderStatus { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shoppa.Data.Models;

[Table("orders")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_date", TypeName = "timestamp without time zone")]
    public DateTime? OrderDate { get; set; }

    [Column("total_price")]
    [Precision(10, 2)]
    public decimal TotalPrice { get; set; }

    [Column("payment_status")]
    [StringLength(50)]
    public string? PaymentStatus { get; set; }

    [Column("shipping_status")]
    [StringLength(50)]
    public string? ShippingStatus { get; set; }

    [Column("order_status")]
    [StringLength(50)]
    public string? OrderStatus { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}

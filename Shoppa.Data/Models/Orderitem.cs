using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Shoppa.Data.Models;

[Table("orderitems")]
public partial class Orderitem
{
    [Key]
    [Column("orderitem_id")]
    public int OrderitemId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    public decimal TotalItemPrice => Quantity * Price;

    [ForeignKey("OrderId")]
    [InverseProperty("Orderitems")]
    [JsonIgnore]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Orderitems")]
    public virtual Product Product { get; set; } = null!;
}

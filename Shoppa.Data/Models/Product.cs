using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Shoppa.Data.Models;

[Table("products")]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    public string ProductName { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [InverseProperty("Product")]
    [JsonIgnore]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}

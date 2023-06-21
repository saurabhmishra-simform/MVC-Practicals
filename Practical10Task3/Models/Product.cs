using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical10Task3.Models;
[Table("Product")]
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
    public string Discription { get; set; } = null!;
}

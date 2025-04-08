using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities;
public class Product
{
    public int? Id { get; set; }  // Primary Key

    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Product Name

    [StringLength(500)]
    public string? Description { get; set; } // Product Description

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; } // Product Price

    public int? StockQuantity { get; set; } = 0; // Available Stock

    [Required]
    public int CategoryId { get; set; } // Foreign Key to Category

    public Category? Category { get; set; } // Navigation Property

    public string? ImageUrl { get; set; } // URL for Product Image

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp for Creation
    public DateTime? UpdatedAt { get; set; } // Timestamp for Last Update
}

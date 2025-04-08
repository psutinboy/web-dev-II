public class ProductDto
{
    public int? Id { get; set; }  // Primary Key

    public required string Name { get; set; } // Product Name

    public string? Description { get; set; } // Product Description

    public decimal Price { get; set; } // Product Price

    public int? StockQuantity { get; set; } = 0; // Available Stock

    public int CategoryId { get; set; } // Foreign Key to Category

    public CategoryDto? Category { get; set; } // Navigation Property

    public string? ImageUrl { get; set; } // URL for Product Image
}

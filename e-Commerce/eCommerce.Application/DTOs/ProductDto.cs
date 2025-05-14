public class ProductDto
{
    public int Id { get; set; }  // Primary Key

    public string Name { get; set; } // Product Name

    public string Description { get; set; } // Product Description

    public decimal Price { get; set; } // Product Price

    public int? StockQuantity { get; set; } = 0; // Available Stock

    public int CategoryId { get; set; } // Foreign Key to Category

    public CategoryDto? Category { get; set; } // Navigation Property //Accepts Null

    public string? ImageUrl { get; set; } // URL for Product Image
}

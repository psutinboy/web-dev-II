using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;
public class Product
{
    [Required(ErrorMessage = "Product Name is required")]
    public  string? Name { get; set; }

    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
    public int Quantity { get; set; }

    public decimal Price{get;set;}

    public int Id{get;set;}

    public  string? ImageUrl { get; set; }

     public  string? Description { get; set; }

}
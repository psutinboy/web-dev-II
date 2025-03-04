using MyWebApp.Models; // Include the Models namespace to access Product

namespace MyWebApp.Services;

public class ProductService : IProductService

{

    private readonly IAppLogger _appLogger;

    public ProductService(IAppLogger appLogger)
    {
        _appLogger = appLogger;
    }

    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999 },
        new Product { Id = 2, Name = "Smartphone", Price = 499 },
        new Product { Id = 2, Name = "Camera", Price = 599 }
    };


    public List<Product> GetProducts()
    {
        _appLogger.LogInfo("Fetching product list from database");
        return products;
    }

    public Product GetProduct(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }
    }
}
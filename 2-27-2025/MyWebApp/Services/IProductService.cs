using MyWebApp.Models; // Include the Models namespace to access Product

namespace MyWebApp.Services;

public interface IProductService 
{ 
    List<Product> GetProducts(); 

    Product GetProduct(int id);

    void AddProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(int id);
}

using MyWebApp.Services; // Include the Models namespace to access Product

public interface IDiscountService
{
    decimal ApplyDiscount(decimal price, decimal discountPercentage);
}

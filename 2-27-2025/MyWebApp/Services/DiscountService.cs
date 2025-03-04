using MyWebApp.Services; // Include the Models namespace to access Product

public class DiscountService : IDiscountService
{
    public decimal ApplyDiscount(decimal price, decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Discount percentage must be between 0 and 100.");
        }

        return price - (price * (discountPercentage / 100));
    }
}

//public class NewYearDiscountService : IDiscountService
//{
//    public decimal ApplyDiscount(decimal price, decimal discountPercentage)
//    {
//        if (discountPercentage < 0 || discountPercentage > 100)
//        {
//            throw new ArgumentException("Discount percentage must be between 0 and 100.");
//        }

//        return price - (price * (50 / 100));
//    }
//}



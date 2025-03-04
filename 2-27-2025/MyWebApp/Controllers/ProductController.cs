using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services; // Include the Models namespace to access Product

public class ProductController : Controller
{

    private readonly IAppLogger _appLogger;

    private readonly IProductService _productService;

    public ProductController(IProductService productService, IAppLogger appLogger)
    {
        _productService = productService;
        _appLogger = appLogger;
    }

    // In-memory data for products (can be replaced with database logic later)


    // Action method for displaying all products
    public IActionResult Index()
    {
         _appLogger.LogInfo("Product page accessed.");

        var products = _productService.GetProducts();

        return View(products); // Pass products data to the View

        //return View(_productService.GetProducts());
    }

    public IActionResult ApplyDiscount(int productId, decimal discountPercentage, [FromServices] IDiscountService discountService)
    {
        var product = _productService.GetProduct(productId);
        if (product == null)
        {
            return NotFound();
        }

        decimal discountedPrice = discountService.ApplyDiscount(product.Price, discountPercentage);
        ViewBag.DiscountedPrice = discountedPrice;

        _appLogger.LogInfo("Discount applied");

        return View(product);
    }

    // Action method for displaying a single product by Id
    public IActionResult Details(int id)
    {
        var product = _productService.GetProduct(id);
        if (product == null)
        {
            return NotFound(); // Return 404 if product is not found
        }

        _appLogger.LogInfo("Details page viewed");

        return View(product); // Pass product data to the View
    }

    public IActionResult List()
    {
        var products = _productService.GetProducts();

        _appLogger.LogInfo("List page viewed");

        return View(products);
    }

    // Action method for creating a new product
    public IActionResult Create()
    {
        return View(); // Return empty form for product creation
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            // Add product to the list (in a real app, you'd save it to a database)
            _productService.AddProduct(product);

            _appLogger.LogInfo("Product created");

            return RedirectToAction("Index"); // Redirect to the product listing
        }

        return View(product); // Return the form with validation errors if model is invalid
    }
}

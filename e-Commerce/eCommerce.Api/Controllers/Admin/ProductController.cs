using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using eCommerce.Application.Services;

namespace eCommerce.Web.Controllers
{
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories ?? new List<CategoryDto>(); // Ensure it's not null
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            // if (!ModelState.IsValid)
            // {
            //     var categories = await _categoryService.GetAllCategoriesAsync();
            //     ViewBag.Categories = categories ?? new List<CategoryDto>(); // Ensure it's not null
            //     return View(productDto);
            // }

            await _productService.AddProductAsync(productDto);
            return RedirectToAction("Index");
        }


    }
}
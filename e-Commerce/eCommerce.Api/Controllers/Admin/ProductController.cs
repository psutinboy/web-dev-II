using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using eCommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Web.Controllers
{
    [Authorize]
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
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.Categories = categories ?? new List<CategoryDto>(); // Ensure it's not null
                return View(productDto);
            }

            await _productService.AddProductAsync(productDto);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name", productDto.CategoryId);
                return View(productDto);
            }

            await _productService.UpdateProductAsync(productDto);
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _productService.DeleteProductAsync(Id);
            return RedirectToAction("Index");
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
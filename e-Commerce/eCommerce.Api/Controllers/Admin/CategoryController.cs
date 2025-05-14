using eCommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("admin/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: admin/categories
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return View(categories);
    }

    // GET: admin/categories/create
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: admin/categories/create
    [HttpPost("create")]
    public async Task<IActionResult> Create(CategoryDto categoryDto)
    {
        if (!ModelState.IsValid)
            return View(categoryDto);

        await _categoryService.CreateCategoryAsync(categoryDto);
        return RedirectToAction("Index");
    }

    // GET: admin/categories/edit/{id}
    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        return View(category);
    }

    // GET: admin/categories/details/{id}
    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        return View(category);
    }

    // POST: admin/categories/edit/{id}
    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, CategoryDto categoryDto)
    {
        if (!ModelState.IsValid)
            return View(categoryDto);

        await _categoryService.UpdateCategoryAsync(id, categoryDto);
        return RedirectToAction("Index");
    }

    // POST: admin/categories/delete/{id}
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction("Index");
    }
}

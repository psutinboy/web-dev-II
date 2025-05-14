using Microsoft.AspNetCore.Mvc;
using eCommerce.Application.Services;
using eCommerce.Application.DTOs;
using System.Threading.Tasks;

namespace eCommerce.Web.Controllers.Admin
{
    [Route("admin/inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inventoryItems = await _inventoryService.GetAllProductsAsync();
            return View(inventoryItems);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryDto inventoryDto)
        {
            if (ModelState.IsValid)
            {
                await _inventoryService.CreateInventoryAsync(inventoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryDto);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var inventoryItem = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InventoryDto inventoryDto)
        {
            if (id != inventoryDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _inventoryService.UpdateInventoryAsync(inventoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryDto);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var inventoryItem = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inventoryItem = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _inventoryService.DeleteInventoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
} 
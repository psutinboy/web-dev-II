using AutoMapper;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eCommerce.Application.Services
{
    public interface IInventoryService
    {
        Task CreateInventoryAsync(InventoryDto inventory);
        Task<IEnumerable<InventoryDto>> GetAllProductsAsync();
        Task<InventoryDto> GetInventoryByIdAsync(int id);
        Task UpdateInventoryAsync(InventoryDto inventory);
        Task DeleteInventoryAsync(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper; // AutoMapper for mapping between entities and DTOs

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task CreateInventoryAsync(InventoryDto inventory)
        {
            await _inventoryRepository.AddAsync(new Inventory { Name = inventory.Name, Quantity = inventory.Quantity });
        }

        public async Task<IEnumerable<InventoryDto>> GetAllProductsAsync()
        {
            var products = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryDto>>(products);
        }

        public async Task<InventoryDto> GetInventoryByIdAsync(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryDto>(inventory);
        }

        public async Task UpdateInventoryAsync(InventoryDto inventoryDto)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(inventoryDto.Id.Value);
            if (inventory != null)
            {
                inventory.Name = inventoryDto.Name;
                inventory.Quantity = inventoryDto.Quantity;
                await _inventoryRepository.Update(inventory);
            }
        }

        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            if (inventory != null)
            {
                await _inventoryRepository.Delete(inventory);
            }
        }
    }
}
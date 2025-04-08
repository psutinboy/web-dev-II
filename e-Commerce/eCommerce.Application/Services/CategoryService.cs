using AutoMapper;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Repositories;

namespace eCommerce.Application.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper; // AutoMapper for mapping between entities and DTOs

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var createdCategory = await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryDto>(createdCategory);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(id);
        if (existingCategory == null)
            throw new KeyNotFoundException("Category not found");

        _mapper.Map(categoryDto, existingCategory);
        await _categoryRepository.Update(existingCategory);
        return _mapper.Map<CategoryDto>(existingCategory);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return false;

        await _categoryRepository.Delete(category);
        return true;
    }
}
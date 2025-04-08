namespace eCommerce.Application.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto);
    Task<bool> DeleteCategoryAsync(int id);
}

using TooliRent.Services.DTOs.CategoryDtos;

namespace TooliRent.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetByCategoryIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
    }
}

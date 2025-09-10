using TooliRent.Services.DTOs.CategoryDtos;

namespace TooliRent.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetByCategoryIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto category);
        Task<UpdateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
    }
}

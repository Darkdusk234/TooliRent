using TooliRent.Services.DTOs.CategoryDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Services.Services
{
    internal class CategoryService : ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> GetByCategoryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

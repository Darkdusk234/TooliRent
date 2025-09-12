using AutoMapper;
using TooliRent.Core.Interfaces;
using TooliRent.Core.Models;
using TooliRent.Services.DTOs.CategoryDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Services.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByCategoryIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return category != null ? _mapper.Map<CategoryDto>(category) : null;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category)
        {
            var newCategory = _mapper.Map<Category>(category);

            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            var createdCategory = await _unitOfWork.Categories.GetByIdAsync(newCategory.Id);
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            if(!await CategoryExistsAsync(id))
            {
                return false;
            }

            await _unitOfWork.Categories.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _unitOfWork.Categories.ExistsAsync(id);
        }
    }
}

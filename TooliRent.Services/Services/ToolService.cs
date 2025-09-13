using AutoMapper;
using TooliRent.Core.Interfaces;
using TooliRent.Services.DTOs.ToolDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Services.Services
{
    internal class ToolService : IToolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ToolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToolDto>> GetAllToolsAsync()
        {
            var tools = await _unitOfWork.Tools.GetAllAsync();
            return _mapper.Map<IEnumerable<ToolDto>>(tools);
        }

        public Task<ToolDto?> GetToolByIdAsync(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToolDto>> GetToolsByAvailabilityAsync(bool available)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToolDto>> GetToolsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ToolDto> CreateToolAsync(CreateToolDto createToolDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToolAsync(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToolAsync(int toolId, UpdateToolDto updateToolDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsToolAvailableAsync(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ToolExistsAsync(int toolId)
        {
            throw new NotImplementedException();
        }
    }
}

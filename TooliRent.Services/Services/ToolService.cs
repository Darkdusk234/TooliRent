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

        public async Task<ToolDto?> GetToolByIdAsync(int toolId)
        {
            var tool = await _unitOfWork.Tools.GetByIdAsync(toolId);
            return tool != null ? _mapper.Map<ToolDto>(tool) : null;
        }

        public async Task<IEnumerable<ToolDto>> GetToolsByAvailabilityAsync(bool available)
        {
            var tools = await _unitOfWork.Tools.GetToolsByAvailabilityAsync(available);
            return _mapper.Map<IEnumerable<ToolDto>>(tools);
        }

        public async Task<IEnumerable<ToolDto>> GetToolsByCategoryAsync(int categoryId)
        {
            var tools = await _unitOfWork.Tools.GetToolsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<ToolDto>>(tools);
        }

        public async Task<ToolDto> CreateToolAsync(CreateToolDto createToolDto)
        {
            var newTool = _mapper.Map<Core.Models.Tool>(createToolDto);

            await _unitOfWork.Tools.AddAsync(newTool);
            await _unitOfWork.SaveChangesAsync();

            var createdTool = await _unitOfWork.Tools.GetByIdAsync(newTool.Id);
            return _mapper.Map<ToolDto>(createdTool);
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

        public async Task<bool> ToolExistsAsync(int toolId)
        {
            return await _unitOfWork.Tools.ExistsAsync(toolId);
        }
    }
}

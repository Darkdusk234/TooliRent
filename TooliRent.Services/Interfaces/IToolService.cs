using TooliRent.Services.DTOs;

namespace TooliRent.Services.Interfaces
{
    public interface IToolService
    {
        Task<IEnumerable<ToolDto>> GetAllToolsAsync();
        Task<ToolDto?> GetToolByIdAsync(int toolId);
        Task<IEnumerable<ToolDto>> GetToolsByAvailabilityAsync(bool available);
        Task<IEnumerable<ToolDto>> GetToolsByCategoryAsync(int categoryId);
        Task<ToolDto> CreateToolAsync(CreateToolDto createToolDto);
        Task<bool> UpdateToolAsync(int toolId, UpdateToolDto updateToolDto);
        Task<bool> DeleteToolAsync(int toolId);
        Task<bool> IsToolAvailableAsync(int toolId);
        Task<bool> ToolExistsAsync(int toolId);
    }
}

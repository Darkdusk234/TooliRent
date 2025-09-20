using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TooliRent.Services.DTOs.ToolDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolsController(IToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToolDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTools()
        {
            var tools = await _toolService.GetAllToolsAsync();
            return Ok(tools);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ToolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetToolById(int id)
        {
            var tool = await _toolService.GetToolByIdAsync(id);

            if(tool == null)
            {
                return NotFound("Tool not found.");
            }

            return Ok(tool);
        }

        [HttpGet("isAvailable/{available}")]
        [ProducesResponseType(typeof(IEnumerable<ToolDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToolsByAvailability(bool available)
        {
            var tools = await _toolService.GetToolsByAvailabilityAsync(available);

            return Ok(tools);
        }

        [HttpGet("categoryId/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ToolDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToolsByCategoryId(int categoryId)
        {
            var tools = await _toolService.GetToolsByCategoryAsync(categoryId);
            return Ok(tools);
        }
    }
}

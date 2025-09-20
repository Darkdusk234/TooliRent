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
    }
}

namespace TooliRent.Services.DTOs.ToolDtos
{
    public class UpdateToolDto
    {
        public string ToolType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; } = true;
    }
}

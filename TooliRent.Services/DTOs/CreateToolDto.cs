namespace TooliRent.Services.DTOs
{
    public class CreateToolDto
    {
        public string ToolType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; } = true;
    }
}

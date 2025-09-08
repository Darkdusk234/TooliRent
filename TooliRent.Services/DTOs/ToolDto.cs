namespace TooliRent.Services.DTOs
{
    public class ToolDto
    {
        public int Id { get; set; }
        public string ToolType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool Available { get; set; }
    }
}

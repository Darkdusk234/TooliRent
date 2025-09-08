namespace TooliRent.Services.DTOs
{
    internal interface ToolDto
    {
        public int ToolId { get; set; }
        public string ToolType { get; set; }
        public string Description { get; set; }
        string Category { get; set; }
        public bool Available { get; set; }
    }
}

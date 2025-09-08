namespace TooliRent.Services.DTOs
{
    public class CreateBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public int ToolId { get; set; }
    }
}

namespace TooliRent.Services.DTOs.BookingDtos
{
    public class CreateBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public int ToolId { get; set; }
        public DateTime LastBookedDate { get; set; } = DateTime.UtcNow;
    }
}

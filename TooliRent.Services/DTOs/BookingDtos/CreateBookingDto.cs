namespace TooliRent.Services.DTOs.BookingDtos
{
    public class CreateBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public IList<int> ToolId { get; set; } = [];
        public DateTime StartBookedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastBookedDate { get; set; } = DateTime.UtcNow;
    }
}

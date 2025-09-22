namespace TooliRent.Services.DTOs.BookingDtos
{
    public class UpdateBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public int ToolId { get; set; }
        public bool IsPickedUp { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime StartBookedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastBookedDate { get; set; }
    }
}

namespace TooliRent.Services.DTOs
{
    public class UpdateBookingDto
    {
        public string UserId { get; set; } = string.Empty;
        public int ToolId { get; set; }
        public bool IsPickedUp { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

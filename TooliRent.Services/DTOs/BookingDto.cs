namespace TooliRent.Services.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public int ToolId { get; set; }
        public string ToolType { get; set; } = string.Empty;
        public string? ToolDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPickedUp { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}

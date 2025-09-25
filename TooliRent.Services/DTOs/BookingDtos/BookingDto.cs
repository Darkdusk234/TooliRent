using TooliRent.Services.DTOs.ToolDtos;

namespace TooliRent.Services.DTOs.BookingDtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public IList<int> ToolIds { get; set; } = [];
        public DateTime CreatedDate { get; set; }
        public bool IsPickedUp { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime StartBookedDate { get; set; }
        public DateTime LastBookedDate { get; set; }
        public bool LateReturnHandled { get; set; }

    }
}

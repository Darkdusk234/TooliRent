using System.ComponentModel.DataAnnotations;

namespace TooliRent.Core.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public IList<int> ToolId { get; set; } = [];

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsPickedUp { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public DateTime StartBookedDate {  get; set; } = DateTime.UtcNow;
        public DateTime LastBookedDate { get; set; } = DateTime.UtcNow;

        //Navigational Properties
        public User User { get; set; } = null!;
        public IList<Tool> Tools { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace TooliRent.Core.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int ToolId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsPickedUp { get; set; } = false;
        public DateTime? ReturnDate { get; set; }

        //Navigational Properties
        public User? User { get; set; }
        public Tool? Tool { get; set; }
    }
}

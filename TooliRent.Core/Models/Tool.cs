using System.ComponentModel.DataAnnotations;

namespace TooliRent.Core.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ToolType { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public bool Available { get; set; } = true;


        //Navigational properties
        public Category? Category { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TooliRent.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        //Navigational Properties
        public ICollection<Tool>? Tools { get; set; }
    }
}

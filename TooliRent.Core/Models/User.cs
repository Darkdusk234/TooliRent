using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TooliRent.Core.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

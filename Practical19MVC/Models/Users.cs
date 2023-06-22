using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Practical19MVC.Models
{
    public class Users : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
    }
}

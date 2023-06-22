using System.ComponentModel.DataAnnotations;

namespace Practical19MVC.Models
{
    public class RoleAddModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

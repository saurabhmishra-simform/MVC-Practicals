using System.ComponentModel.DataAnnotations;

namespace Practical17.Models
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

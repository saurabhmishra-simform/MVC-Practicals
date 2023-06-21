using System.ComponentModel.DataAnnotations;

namespace Practical17.Models
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            User = new List<string>();
        }
        public string Id { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;
        public IList<string> User { get; set; }
    }
}

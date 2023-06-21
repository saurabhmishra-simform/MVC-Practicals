using System.ComponentModel.DataAnnotations;


namespace Practical17.Models
{
    public class EditUserModel
    {
        public EditUserModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string MobileNumber { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public IList<string> Roles { get; set; }
        public IList<string> Claims { get; set; }

    }
}

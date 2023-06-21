using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical17.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Student Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Student Age")]
        [Required]
        public int Age { get; set; }
        public int? IsDeleted { get; set; } = 0;
    }
}

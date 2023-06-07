using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical13Task1.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "Employee Name")]
        [Required]
        [StringLength(50, ErrorMessage = "Can not accept more then 50 aplhabets")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Invalid Name")]
        [MinLength(3, ErrorMessage = "Name should contain atlist 3 character")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Age")]
        public int? Age { get; set; }

        public int? IsDeleted { get; set; } = 0;
    }
}

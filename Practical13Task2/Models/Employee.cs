using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical13Task2.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[A-Za-z]+\\s[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Middle Name")]
        [RegularExpression("^[A-Za-z]+\\s[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression("^[A-Za-z]+\\s[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Mobile Number")]
        [Required]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [StringLength(10)]
        public string MobileNumber { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [RegularExpression("^[A-Za-z]+\\s[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
        [StringLength(100)]
        public string? Address { get; set; } = string.Empty;

        [Display(Name = "Salary")]
        [Required]
        public decimal Salary { get; set; }

        public int? IsDeleted { get; set; } = 0;

        [ForeignKey("Designation")]
        [Display(Name ="Designation Name")]
        public int? DesignationId { get; set; }

        public virtual Designation? Designations { get; set; }
        
    }
}

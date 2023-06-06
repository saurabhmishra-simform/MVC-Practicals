using System.ComponentModel.DataAnnotations;

namespace Practical11Task1.Models
{
    public class Student
    {
        [Display(Name = "Student Id")]
        [Required]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Student Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set;} = string.Empty;

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Student Address")]
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}

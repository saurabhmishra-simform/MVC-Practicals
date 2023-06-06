using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Practical11Task2.Models
{
    public class Student
    {
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Student Email")]
        public string StudentEmail { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Student Address")]
        public string Address { get; set; } = string.Empty;
    }
}

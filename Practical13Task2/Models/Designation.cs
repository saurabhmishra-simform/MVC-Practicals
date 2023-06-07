using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical13Task2.Models
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "Designation Name")]
        [RegularExpression("^[A-Za-z]+\\s[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; } = string.Empty;
        public int? IsDeleted { get; set; } = 0;
    }
}

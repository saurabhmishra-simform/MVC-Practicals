using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical14Task1.Models;

[Table("Employee")]
public partial class Employee
{
    [System.ComponentModel.DataAnnotations.Key]
    public int? Id { get; set; }
    [Required]
    [Display(Name = "Employee Name")]
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Sorry, invalid input")]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime Dob { get; set; }

    [Display(Name = "Age")]
    public int? Age { get; set; }
    public int? IsDeleted { get; set; } = 0;
}

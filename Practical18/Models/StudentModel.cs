﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical18.Models
{
    [Table("Student")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(10,MinimumLength = 10)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public int IsDelete { get; set; } = 0;
    }
}

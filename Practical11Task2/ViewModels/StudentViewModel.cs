using Practical11Task2.Models;

namespace Practical11Task2.ViewModels
{
    public class StudentViewModel
    {
        public Student? Student { get; set; }
        public IEnumerable<Student>? Students { get; set; }
        public string? PageTitle { get; set; }
    }
}

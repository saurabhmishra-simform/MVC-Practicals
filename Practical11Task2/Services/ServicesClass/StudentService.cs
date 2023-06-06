using Practical11Task2.Models;
using Practical11Task2.Services.ServicesInterfaces;

namespace Practical11Task2.Services.ServicesClass
{
    public class StudentService : IStudentService
    {
        readonly static List<Student> students = new List<Student>()
        {
            new Student()
            {
                StudentId = 1,
                StudentName = "Saurabh",
                StudentEmail = "saurabh@gmail.com",
                DateOfBirth = DateTime.Today,
                Address = "Anand"
            },
            new Student()
            {
                StudentId = 2,
                StudentName = "Jimit",
                StudentEmail = "jimit@gmail.com",
                DateOfBirth = DateTime.Today,
                Address = "Vadodara"
            },
        };
        public int FindId(int? id)
        {
            var student = GetStudent(id);
            return (student != null) ? 0 : 1;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return students;
        }

        public Student GetSingleStudent(int? id)
        {
            var student = GetStudent(id);
            if (student != null)
            {
                return student;
            }
            return new Student();
        }

        public bool RemoveStudent(int? id)
        {
            var student = GetStudent(id);
            if (student != null)
            {
                students.Remove(student);
            }
            return true;
        }

        public void Save(Student student)
        {
            var studentInfo = students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (studentInfo is null)
            {
                students.Add(student);
            }
            else
            {
                studentInfo.StudentName = student.StudentName;
                studentInfo.StudentEmail = student.StudentEmail;
                studentInfo.DateOfBirth = student.DateOfBirth;
                studentInfo.Address = student.Address;
            }
        }
        public Student UpdateStudent(int? id)
        {
            return GetSingleStudent(id);
        }
        private Student? GetStudent(int? id)
        {
            var student = students.FirstOrDefault(x => x.StudentId == id);
            return student;
        }
    }
}

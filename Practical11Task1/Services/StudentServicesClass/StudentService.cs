using Microsoft.AspNetCore.Mvc;
using Practical11Task1.Models;
using Practical11Task1.Services.StudentServicesInterfaces;

namespace Practical11Task1.Services.StudentServicesClass
{

    public class StudentService : IStudentService
    {
        static List<Student> students = new List<Student>()
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
        public bool RemoveStudent(int? id)
        {
            var student = GetStudent(id);
            if (student != null)
            {
                students.Remove(student);
            }
            return true;
        }
        public Student GetSingleStudent(int? id)
        {
            var student = GetStudent(id);
            if(student != null)
            {
                return student;
            }
            return new Student();
        }
        public Student UpdateStudent(int? id)
        {
            return GetSingleStudent(id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return students;

        }
        public Student? GetStudent(int? id)
        {
            var student = students.FirstOrDefault(x => x.StudentId == id);
            return student;
        }
        public int FindId(int? id)
        {
            var student = GetStudent(id);
            return (student != null) ? 0 : 1;
        }
    }
}

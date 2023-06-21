using Practical17.Data;
using Practical17.Models;
using Practical17.Services.ServiceInterfaces;

namespace Practical17.Services.ServiceClass
{
    public class StudentService : IStudentService
    {
        private readonly AppDBContext _context;
        public StudentService(AppDBContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int? id)
        {
            var student = GetSingleStudent(id);
            if (student != null)
            {
                student.IsDeleted = 1;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students.Where(x => x.IsDeleted == 0).ToList();
        }

        public Student GetSingleStudent(int? id)
        {
            var student = _context.Students.FirstOrDefault(x=>x.Id == id && x.IsDeleted==0);
            return student!;
        }

        public void UpdateStudent(Student student)
        {
            var studentUpdate = GetSingleStudent(student.Id);
            if(studentUpdate != null)
            {
                studentUpdate.Name = student.Name;
                studentUpdate.Email = student.Email;
                studentUpdate.Dob = student.Dob;
                studentUpdate.Age = student.Age;
                _context.SaveChanges();
            }
        }
    }
}

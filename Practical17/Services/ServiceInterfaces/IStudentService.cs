using Practical17.Models;

namespace Practical17.Services.ServiceInterfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudent();
        Student GetSingleStudent(int? id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int? id);
    }
}

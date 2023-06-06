using Practical11Task2.Models;

namespace Practical11Task2.Services.ServicesInterfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudent();
        Student GetSingleStudent(int? id);
        void Save(Student student);
        Student UpdateStudent(int? id);
        bool RemoveStudent(int? id);
        int FindId(int? id);
    }
}

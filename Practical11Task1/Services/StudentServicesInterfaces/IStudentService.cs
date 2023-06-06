using Microsoft.AspNetCore.Mvc;
using Practical11Task1.Models;

namespace Practical11Task1.Services.StudentServicesInterfaces
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

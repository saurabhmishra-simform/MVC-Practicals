using Practical18.Models;
using Practical18.RequestModel;

namespace Practical18.Services.InterfaceService
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel GetSingleStudent(int? id);
        IEnumerable<StudentModel> AddStudent(StudentRequestModel request);
        StudentModel UpdateStudent(int? id, StudentRequestModel student);
        StudentModel DeleteStudent(int? id);
    }
}

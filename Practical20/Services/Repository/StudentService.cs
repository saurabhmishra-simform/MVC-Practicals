using Practical_20.Services.Interfaces;
using Practical20.Models;

namespace Practical_20.Services.Repository
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddStudent(Students students)
        {
            var student = new Students
            {
                Email = students.Email,
                StudentName = students.StudentName,
                Phone = students.Phone,
            };

            _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateStudent(Students students)
        {
            _unitOfWork.StudentRepository.Update(students);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Students>> GetAll()
            => await _unitOfWork.StudentRepository.GetAll();

        public Task<Students> GetStudentbyId(int id)
        {
            var student = _unitOfWork.StudentRepository.GetStudentById(id);
            return student;
        }
        public void DeleteStudent(Students students)
        {
            _unitOfWork.StudentRepository.Delete(students);
            _unitOfWork.CommitAsync();
        }
    }
}

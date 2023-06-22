using Practical20.Models;

namespace Practical_20.Services.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Students>
    {
        Task<Students> GetStudentById(int studentId);
    }
}

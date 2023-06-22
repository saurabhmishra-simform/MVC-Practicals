using Practical20.Models;
using Practical_20.Services.Interfaces;

namespace Practical_20.Services.Repository
{
    public class StudentRepository : GenericRepository<Students>, IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Students> GetStudentById(int id)
        {
            return await _dbContext.Students.FindAsync(id);

        }
    }
}

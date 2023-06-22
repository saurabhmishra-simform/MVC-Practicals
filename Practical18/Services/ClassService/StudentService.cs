using AutoMapper;
using Practical18.Data;
using Practical18.Models;
using Practical18.RequestModel;
using Practical18.Services.InterfaceService;

namespace Practical18.Services.ClassService
{
    public class StudentService : IStudentService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public StudentService(AppDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<StudentModel> AddStudent(StudentRequestModel request)
        {
            if(request != null)
            {
                var student = _mapper.Map<StudentModel>(request);
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            return GetAllStudents();
        }

        public StudentModel DeleteStudent(int? id)
        {
            var student = _context.Students.FirstOrDefault(x=>x.StudentId == id && x.IsDelete==0);
            if(student != null)
            {
                student.IsDelete = 1;
                _context.SaveChanges();
            }
            return student!;
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _context.Students.Where(x => x.IsDelete == 0).ToList();
        }

        public StudentModel GetSingleStudent(int? id)
        {
            var student = _context.Students.FirstOrDefault(x=>x.StudentId==id && x.IsDelete==0);
            return student!;
        }

        public StudentModel UpdateStudent(int?id,StudentRequestModel student)
        {
            var studentUpdate = _context.Students.FirstOrDefault(x => x.StudentId == id && x.IsDelete == 0);
            if (studentUpdate != null)
            {
                studentUpdate.StudentName = student.StudentName;
                studentUpdate.Email = student.Email;
                studentUpdate.PhoneNumber = student.PhoneNumber;
                studentUpdate.Dob = student.Dob;
                _context.SaveChanges();
            }
            return studentUpdate!;
        }
    }
}

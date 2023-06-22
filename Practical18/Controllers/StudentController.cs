using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical18.Models;
using Practical18.RequestModel;
using Practical18.Services.InterfaceService;

namespace Practical18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult ShowAllStudent()
        {
            var student = _studentService.GetAllStudents();
            return Ok(student);
        }
        [HttpGet("ShowSingleStudent/{id}")]
        public IActionResult ShowSingleStudent(int? id)
        {
            var student = _studentService.GetSingleStudent(id);
            if(student == null)
            {
                return StatusCode(404, "Sorry,record not found!!");
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudentRecord(StudentRequestModel student)
        {
            if (ModelState.IsValid)
            {
                var result = _studentService.AddStudent(student);
                return Ok(result);
            }
            return NotFound("Sorry,Model state not valid!!");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudentRecord(int? id, StudentRequestModel student)
        {
            var result = _studentService.UpdateStudent(id, student);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Sorry,record not found!!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int? id)
        {
            var result = _studentService.DeleteStudent(id);
            if(result == null)
            {
                return NotFound("Sorry,record not found!!");
            }
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical17.Models;
using Practical17.Services.ServiceInterfaces;

namespace Practical17.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var student = _studentService.GetAllStudent();
            return View(student);
        }
        public IActionResult Details(int? id)
        {
            var student = _studentService.GetSingleStudent(id);
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Student student)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if(student.Id == null)
            {
                _studentService.AddStudent(student);
            }
            else
            {
                _studentService.UpdateStudent(student);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var student = _studentService.GetSingleStudent(id);
            if(student != null)
            {
                return View("Create", student);
            }
            else
            {
                return NotFound("Sorry, record not found!!");
            }
        }
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                _studentService.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound("Sorry, record not found!");
            }
        }
    }
}

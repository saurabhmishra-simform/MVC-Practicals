using Microsoft.AspNetCore.Mvc;
using Practical11Task2.Models;
using Practical11Task2.Services.ServicesInterfaces;
using Practical11Task2.ViewModels;

namespace Practical11Task2.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Students = _studentService.GetAllStudent(),
                PageTitle = "Index"
            };
            return View(studentViewModel);
        }
        public IActionResult Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                PageTitle = "Create"
            };
            return View("Index", studentViewModel);
        }
        public IActionResult Details(int? id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = _studentService.GetSingleStudent(id),
                PageTitle = "Details"
            };
            return View("Index", studentViewModel);
        }
        public IActionResult AddEdit(Student student)
        {
            _studentService.Save(student);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = _studentService.UpdateStudent(id),
                PageTitle = "Create"
            };
            ViewBag.id = "Yes";
            return View("Index", studentViewModel);
        }
        public IActionResult Delete(int? id)
        {
            _studentService.RemoveStudent(id);
            return RedirectToAction("Index");

        }
        public int FindId(int? id)
        {
            var student = _studentService.FindId(id);
            return student;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Practical11Task1.Models;
using Practical11Task1.Services.StudentServicesClass;
using Practical11Task1.Services.StudentServicesInterfaces;

namespace Practical11Task1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentServices;
        public StudentController(IStudentService studentServices)
        {
            _studentServices = studentServices;
        }
        public IActionResult Index()
        {
            var result = _studentServices.GetAllStudent();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            var result = _studentServices.GetSingleStudent(id);
            return View(result);
        }
        public IActionResult AddEdit(Student student)
        {
            _studentServices.Save(student);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var result = _studentServices.UpdateStudent(id);
            ViewBag.id = "Yes";
            return View("Create", result);
        }
        public IActionResult Delete(int? id)
        {
            _studentServices.RemoveStudent(id);
            return RedirectToAction("Index");
        }
        public int FindId(int? id)
        {
            int result = _studentServices.FindId(id);
            return result;
        }
    }
}

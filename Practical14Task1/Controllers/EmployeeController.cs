using Microsoft.AspNetCore.Mvc;
using Practical14Task1.Models;
using Practical14Task1.Services.ServiceClass;
using Practical14Task1.Services.ServiceInterfaces;

namespace Practical14Task1.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index(int? page)
        {
            var employee = _employeeService.GetAllEmployee(page);
            return View(employee);
        }
        public IActionResult Details(int? id)
        {
            var employee = _employeeService.GetSingleEmployee(id);
            return View(employee);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if(employee.Id == null)
            {
                _employeeService.AddEmployee(employee);
            }
            else
            {
                _employeeService.UpdaterEmployee(employee);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetSingleEmployee(id);
            if(employee != null)
            {
                return View("Create", employee);
            }
            else
            {
                return NotFound("Sorry, employee not found!!");
            }
        }
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public IActionResult Search(string name)
        {
            var result = _employeeService.SearchByName(name);
            return PartialView("_SearchResult", result);
        }
    }
}

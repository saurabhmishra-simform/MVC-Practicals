using Microsoft.AspNetCore.Mvc;
using Practical13Task1.Data;
using Practical13Task1.Models;
using Practical13Task1.Services.ServicesInterfaces;

namespace Practical13Task1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployee();
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
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if(employee.Id == null)
            {
                _employeeService.AddEmployee(employee);
            }
            else
            {
                _employeeService.UpdateEmployee(employee);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var employee = _employeeService.GetSingleEmployee(id);
            if (employee != null)
            {
                return View("Create", employee);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}

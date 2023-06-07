using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practical13Task2.Models;
using Practical13Task2.Services.ServiceInterfaces;

namespace Practical13Task2.Controllers
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
        public IActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(_employeeService.GetDesignationList(), "Id", "DesignationName");
            return View();
        }
        public IActionResult Details(int? id)
        {
            var employee = _employeeService.GetSingleEmployee(id);
            return View(employee);
        }
        public IActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (employee.Id == null)
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
            if(employee != null)
            {
                ViewBag.DesignationId = new SelectList(_employeeService.GetDesignationList(), "Id", "DesignationName");
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

using Microsoft.AspNetCore.Mvc;
using Practical13Task2.Models;
using Practical13Task2.Services.ServiceInterfaces;

namespace Practical13Task2.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
           _designationService = designationService;
        }

        public IActionResult Index()
        {
            var designation = _designationService.GetAllDesignation();
            return View(designation);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Designation designation)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if(designation.Id == null)
            {
                _designationService.AddDesignation(designation);
            }
            else
            {
                _designationService.UpdateDesignation(designation);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            var designation = _designationService.GetSingleDesignation(id);
            return View(designation);
        }
        public IActionResult Edit(int? id)
        {
            var designation = _designationService.GetSingleDesignation(id);
            if (designation != null)
            {
                return View("Create", designation);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _designationService.DeleteDesignation(id);
            return RedirectToAction("Index");
        }
        public int CountEmployee(int? id)
        {
            var empployeeCount = _designationService.CountEmployee(id);
            return empployeeCount;
        }
    }
}

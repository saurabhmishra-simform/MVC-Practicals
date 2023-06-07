using Microsoft.EntityFrameworkCore;
using Practical13Task2.Data;
using Practical13Task2.Models;
using Practical13Task2.Services.ServiceInterfaces;

namespace Practical13Task2.Services.ServiceClasses
{
    public class DesignationService : IDesignationService
    {
        private readonly EmployeeDesignationContext _context;
        public DesignationService(EmployeeDesignationContext context)
        {
            _context = context;
        }
        public void AddDesignation(Designation designation)
        {
            _context.Designations.Add(designation);
            _context.SaveChanges();
        }

        public void DeleteDesignation(int? id)
        {
            var designation = _context.Designations.FirstOrDefault(x => x.Id == id);
            if (designation != null)
            {
                designation.IsDeleted = 1;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Designation> GetAllDesignation()
        {
            return _context.Designations.Where(x => x.IsDeleted == 0).ToList();
        }

        public Designation GetSingleDesignation(int? id)
        {
            var designation = _context.Designations.FirstOrDefault(x => x.Id == id);
            return designation;
        }

        public void UpdateDesignation(Designation designation)
        {
            var designationUpdate = _context.Designations.FirstOrDefault(x => x.Id == designation.Id);
            if (designationUpdate != null)
            {
                designationUpdate.DesignationName = designation.DesignationName;
            }
            _context.SaveChanges();
        }
        public int CountEmployee(int? id)
        {
            var employee = _context.Employees.Include(x => x.Designations).Where(x => x.DesignationId == id && x.IsDeleted == 0).Count();
            return employee;
        }
    }
}

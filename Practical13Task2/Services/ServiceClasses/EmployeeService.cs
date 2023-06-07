using Microsoft.EntityFrameworkCore;
using Practical13Task2.Data;
using Practical13Task2.Models;
using Practical13Task2.Services.ServiceInterfaces;

namespace Practical13Task2.Services.ServiceClasses
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDesignationContext _context;
        public EmployeeService(EmployeeDesignationContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int? id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                employee.IsDeleted = 1;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var employee = _context.Employees.Where(x => x.IsDeleted == 0).Include(x => x.Designations).ToList();
            return employee;
        }

        public Employee GetSingleEmployee(int? id)
        {
            var employee = _context.Employees.Include(x => x.Designations).FirstOrDefault(x => x.Id == id);
            return employee!;
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeUpdate = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (employeeUpdate != null)
            {
                employeeUpdate.FirstName = employee.FirstName;
                employeeUpdate.MiddleName = employee.MiddleName;
                employeeUpdate.LastName = employee.FirstName;
                employeeUpdate.MobileNumber = employee.MobileNumber;
                employeeUpdate.DOB = employee.DOB;
                employeeUpdate.Salary = employee.Salary;
                employeeUpdate.Address = employee.Address;
                employeeUpdate.DesignationId = employee.DesignationId;
            }
            _context.SaveChanges();
        }
        public IEnumerable<Designation> GetDesignationList()
        {
            var designation = _context.Designations.Where(x => x.IsDeleted == 0);
            return designation;
        }
    }
}

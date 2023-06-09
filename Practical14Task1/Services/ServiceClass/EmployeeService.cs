using Practical14Task1.Models;
using Practical14Task1.Services.ServiceInterfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Practical14Task1.Services.ServiceClass
{
    public class EmployeeService : IEmployeeService
    {
        public readonly MvcpracticalContext _context;
        public EmployeeService(MvcpracticalContext context)
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
            var employee = _context.Employees.FirstOrDefault(x=>x.Id == id && x.IsDeleted==0);
            if (employee != null)
            {
                employee.IsDeleted = 1;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployee(int? page)
        {
            int pageSize = 10;
            int pageIndex = page ?? 1;
            var employee = _context.Employees.Where(x => x.IsDeleted == 0).AsQueryable();
            var paginatedList = PaginatedList<Employee>.CreateAsync(employee, pageIndex, pageSize);
            return paginatedList;
        }

        public Employee GetSingleEmployee(int? id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id && x.IsDeleted == 0);
            return employee!;
        }

        public void UpdaterEmployee(Employee employee)
        {
            var employeeUpdate = _context.Employees.FirstOrDefault(x=>x.Id == employee.Id);
            if (employeeUpdate != null)
            {
                employeeUpdate.Name = employee.Name;
                employeeUpdate.Dob = employee.Dob;
                employeeUpdate.Age = employee.Age;
            }
            _context.SaveChanges();
        }
        public IEnumerable<Employee> SearchByName(string name)
        {
            var employee = _context.Employees.Where(x => x.IsDeleted == 0 && x.Name.Contains(name)).ToList();
            return employee;
        }
    }
}

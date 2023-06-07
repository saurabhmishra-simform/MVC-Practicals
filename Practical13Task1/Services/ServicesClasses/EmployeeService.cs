using Practical13Task1.Data;
using Practical13Task1.Models;
using Practical13Task1.Services.ServicesInterfaces;

namespace Practical13Task1.Services.ServicesClasses
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        public void DeleteEmployee(int? id)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                employee.IsDeleted = 1;
                _employeeContext.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var employee = _employeeContext.Employees.Where(x => x.IsDeleted == 0).ToList();
            return employee;
        }

        public Employee GetSingleEmployee(int? id)
        {
            var employee = GetEmployee(id);
            return employee!;
        }
        
        public void UpdateEmployee(Employee employee)
        {
            var employeeDB = _employeeContext.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (employeeDB != null)
            {
                employeeDB.Name = employee.Name;
                employeeDB.DOB = employee.DOB;
                employeeDB.Age = employee.Age;
            }
            _employeeContext.SaveChanges();
        }

        private Employee GetEmployee(int? id)
        {
            return _employeeContext.Employees.FirstOrDefault(x => x.Id == id)!;
        }
        
    }
}

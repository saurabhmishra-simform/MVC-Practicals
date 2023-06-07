using Practical13Task1.Models;

namespace Practical13Task1.Services.ServicesInterfaces
{
    public interface IEmployeeService
    {
        Employee GetSingleEmployee(int? id);
        IEnumerable<Employee> GetAllEmployee();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int? id);
    }
}

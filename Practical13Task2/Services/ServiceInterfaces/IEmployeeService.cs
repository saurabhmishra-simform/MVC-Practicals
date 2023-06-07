using Practical13Task2.Models;

namespace Practical13Task2.Services.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Employee GetSingleEmployee(int? id);
        IEnumerable<Employee> GetAllEmployee();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int? id);
        IEnumerable<Designation> GetDesignationList();
    }
}

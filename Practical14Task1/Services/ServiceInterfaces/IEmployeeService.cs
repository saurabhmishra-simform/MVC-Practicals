using Practical14Task1.Models;

namespace Practical14Task1.Services.ServiceInterfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee(int? page);
        Employee GetSingleEmployee(int? id);
        void AddEmployee(Employee employee);
        void UpdaterEmployee(Employee employee);
        void DeleteEmployee(int? id);
        IEnumerable<Employee> SearchByName(string name);
    }
}

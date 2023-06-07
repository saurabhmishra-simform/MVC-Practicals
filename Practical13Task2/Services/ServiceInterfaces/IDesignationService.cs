using Practical13Task2.Models;

namespace Practical13Task2.Services.ServiceInterfaces
{
    public interface IDesignationService
    {
        Designation GetSingleDesignation(int? id);
        IEnumerable<Designation> GetAllDesignation();
        void AddDesignation(Designation designation);
        void UpdateDesignation(Designation designation);
        void DeleteDesignation(int? id);
        int CountEmployee(int? id);
    }
}

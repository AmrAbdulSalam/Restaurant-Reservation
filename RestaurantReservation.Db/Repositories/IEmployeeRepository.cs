using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> CreateEmployeeAsync(Employees newEmployee);
        Task DeleteEmployeeAsync(int employeeId);
        Task<Employees> GetEmployeeAsync(int employeeId);
        Task UpdateEmployeeAsync(Employees updateEmployee);
    }
}
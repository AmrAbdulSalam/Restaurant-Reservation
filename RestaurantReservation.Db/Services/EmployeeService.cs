using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly RestaurantReservationDbContext _dbContext;

        public EmployeeService(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
            _employeeRepository = new EmployeeRepository(_dbContext);
        }

        public async Task<int> CreateEmployeeAsync(Employees newEmployee)
        {
            return await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }

        public async Task<Employees> GetEmployeeAsync(int employeeId)
        {
            return await _employeeRepository.GetEmployeeAsync(employeeId);
        }

        public async Task UpdateEmployeeAsync(Employees updateEmployee)
        {
            await _employeeRepository.UpdateEmployeeAsync(updateEmployee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeId);
        }

        public async Task<List<Employees>> ListManagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }

        public async Task<bool> EmployeeExists(int employeeId)
        {
            return await _employeeRepository.EmployeeExists(employeeId);
        }

        public double CalculateAverageOrderAmount(int employeeId)
        {
            return _employeeRepository.CalculateAverageOrderAmount(employeeId);
        }
    }
}
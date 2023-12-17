using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEmployeeAsync(Employees newEmployee)
        {
            if (newEmployee == null)
            {
                throw new ArgumentNullException(nameof(newEmployee));
            }
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee.Id;
        }

        public async Task<Employees> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await GetEmployeeAsync(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employees updateEmployee)
        {
            if (!await EmployeeExists(updateEmployee.Id))
            {
                throw new ArgumentNullException(nameof(updateEmployee));
            }
            _context.Employees.Update(updateEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employees>> ListManagersAsync()
        {
            var managers = await _context.Employees
                .Where(a => a.Position == EmployeePositions.Manager)
                .OrderBy(a => a.FirstName)
                .ToListAsync();
            return managers;
        }

        public async Task<bool> EmployeeExists(int employeeId)
        {
            return await _context.Employees.AnyAsync(employee => employee.Id == employeeId);
        }

        public double CalculateAverageOrderAmount(int employeeId)
        {
            var average = _context.Orders
                .Where(a => a.EmployeesId == employeeId)
                .Average(a => a.TotalAmount);
            return average;
        }
    }
}
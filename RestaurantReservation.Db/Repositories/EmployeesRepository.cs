using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeesRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public EmployeesRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployee(Employees newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee.Id;
        }
        public async Task<Employees> GetEmployee(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }
        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await GetEmployee(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEmployee(Employees updateEmployee)
        {
            _context.Employees.Update(updateEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
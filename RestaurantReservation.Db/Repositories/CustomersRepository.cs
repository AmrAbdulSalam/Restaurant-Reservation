using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomersRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomersRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomer(Customers newCustomer)
        {
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id;
        }
        public async Task DeleteCustomer(int customerId)
        {
            var customer = await GetCustomer(customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<Customers> GetCustomer(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return customer;
        }
        public async Task UpdateCustomer(Customers updatedCustomer)
        {
            _context.Customers.Update(updatedCustomer);
            await _context.SaveChangesAsync();
        }
    }
}
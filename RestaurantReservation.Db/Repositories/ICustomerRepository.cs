using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomerAsync(Customers newCustomer);
        Task DeleteCustomerAsync(int customerId);
        Task<Customers> GetCustomerAsync(int customerId);
        Task UpdateCustomerAsync(Customers updatedCustomer);
    }
}
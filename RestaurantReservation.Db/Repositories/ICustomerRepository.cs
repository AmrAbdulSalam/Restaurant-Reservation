using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{

    public interface ICustomerRepository
    {
        /// <summary>
        /// Creating a new customer
        /// </summary>
        /// <param name="newCustomer">The created customer entity</param>
        /// <returns></returns>
        Task<int> CreateCustomerAsync(Customers newCustomer);

        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <param name="customerId">Passing existing customer id</param>
        /// <returns></returns>
        Task DeleteCustomerAsync(int customerId);

        /// <summary>
        /// Get an existing Customer
        /// </summary>
        /// <param name="customerId">Passing existing customer id</param>
        /// <returns></returns>
        Task<Customers> GetCustomerAsync(int customerId);

        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <param name="updatedCustomer">Passing an existing customer as parameter</param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customers updatedCustomer);
    }
}
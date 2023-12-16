using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Creating a new customer
        /// </summary>
        /// <param name="newCustomer">The created customer entity</param>
        /// <returns>The new customer Id</returns>
        Task<int> CreateCustomerAsync(Customers newCustomer);

        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <param name="customerId">Passing existing customer id</param>
        Task DeleteCustomerAsync(int customerId);

        /// <summary>
        /// Get an existing Customer
        /// </summary>
        /// <param name="customerId">Passing existing customer id</param>
        /// <returns>The existing customer</returns>
        Task<Customers> GetCustomerAsync(int customerId);

        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <param name="updatedCustomer">Passing an existing customer as parameter</param>
        Task UpdateCustomerAsync(Customers updatedCustomer);
    }
}
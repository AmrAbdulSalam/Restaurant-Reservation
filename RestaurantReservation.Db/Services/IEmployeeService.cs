using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Creating a new employee
        /// </summary>
        /// <param name="newEmployee">The created employee entity</param>
        /// <returns>The new employee Id</returns>
        Task<int> CreateEmployeeAsync(Employees newEmployee);

        /// <summary>
        /// Delete an existing employee
        /// </summary>
        /// <param name="employeeId">Passing existing employee id</param>
        Task DeleteEmployeeAsync(int employeeId);

        /// <summary>
        /// Get an existing employee
        /// </summary>
        /// <param name="employeeId">Passing existing employee id</param>
        /// <returns>The existing employee</returns>
        Task<Employees> GetEmployeeAsync(int employeeId);

        /// <summary>
        /// List all mangers in the the Employee table
        /// </summary>
        /// <returns>List of employees who are managers</returns>
        Task<List<Employees>> ListManagersAsync();

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="updateEmployee">Passing The created employee entity</param>
        Task UpdateEmployeeAsync(Employees updateEmployee);

        /// <summary>
        /// Check if employee exists in the database
        /// </summary>
        /// <param name="employeeId">Passing an existing employee id</param>
        /// <returns>bool value if the employee is found or not</returns>
        Task<bool> EmployeeExists(int employeeId);

        /// <summary>
        /// Calcualte the average orders for employee
        /// </summary>
        /// <param name="employeeId">Passing existing employee id</param>
        /// <returns>Average number of orders</returns>
        double CalculateAverageOrderAmount(int employeeId);
    }
}
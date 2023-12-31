﻿using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Creating a new employee
        /// </summary>
        /// <param name="newEmployee">The created employee entity</param>
        /// <returns></returns>
        Task<int> CreateEmployeeAsync(Employees newEmployee);

        /// <summary>
        /// Delete an existing employee
        /// </summary>
        /// <param name="employeeId">Passing existing employee id</param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(int employeeId);

        /// <summary>
        /// Get an existing employee
        /// </summary>
        /// <param name="employeeId">Passing existing employee id</param>
        /// <returns></returns>
        Task<Employees> GetEmployeeAsync(int employeeId);

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="updateEmployee">Passing The created employee entity</param>
        /// <returns></returns>
        Task UpdateEmployeeAsync(Employees updateEmployee);
    }
}
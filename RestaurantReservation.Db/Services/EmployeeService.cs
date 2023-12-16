﻿using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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
    }
}
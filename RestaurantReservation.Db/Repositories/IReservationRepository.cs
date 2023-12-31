﻿using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="reservation">The created reservationg entity</param>
        /// <returns>The new Reservationg Id</returns>
        Task<int> CreateReservationAsync(Reservations reservation);

        /// <summary>
        /// Delete an existing reservation
        /// </summary>
        /// <param name="reservationId">Passing Reservation Id</param>
        Task DeleteReservationAsync(int reservationId);

        /// <summary>
        /// Get an existing reservation
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns>Reservation object</returns>
        Task<Reservations> GetReservationsAsync(int reservationId);

        /// <summary>
        /// Get resevationg by passing customer ID
        /// </summary>
        /// <param name="customerId">Passing an existing customer id</param>
        /// <returns>List of Reservationg based on customer id</returns>
        Task<List<Reservations>> GetReservationsByCustomerAsync(int customerId);

        /// <summary>
        /// Update an existing reservation
        /// </summary>
        /// <param name="updateReservation">Passing reservation entity</param>
        Task UpdateReservationAsync(Reservations updateReservation);
    }
}
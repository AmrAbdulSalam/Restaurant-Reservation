﻿using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<int> CreateReservationAsync(Reservations reservation)
        {
            return await _reservationRepository.CreateReservationAsync(reservation);
        }

        public async Task<Reservations> GetReservationsAsync(int reservationId)
        {
            return await _reservationRepository.GetReservationsAsync(reservationId);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationRepository.DeleteReservationAsync(reservationId);
        }

        public async Task UpdateReservationAsync(Reservations updateReservation)
        {
            await _reservationRepository.UpdateReservationAsync(updateReservation);
        }

        public async Task<List<Reservations>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }
    }
}
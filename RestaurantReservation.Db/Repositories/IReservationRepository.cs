using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        Task<int> CreateReservationAsync(Reservations reservation);
        Task DeleteReservationAsync(int reservationId);
        Task<Reservations> GetReservationsAsync(int reservationId);
        Task<List<Reservations>> GetReservationsByCustomerAsync(int customerId);
        Task UpdateReservationAsync(Reservations updateReservation);
    }
}
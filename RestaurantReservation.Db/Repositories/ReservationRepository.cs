using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateReservationAsync(Reservations reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }

        public async Task<Reservations> GetReservationsAsync(int reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await GetReservationsAsync(reservationId);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservations updateReservation)
        {
            if (await GetReservationsAsync(updateReservation.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateReservation));
            }
            _context.Reservations.Update(updateReservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservations>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await _context.Reservations
                .Where(a => a.CustomersId == customerId)
                .OrderBy(a => a.ReservationDate)
                .ToListAsync();
            return reservations;
        }
    }
}
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public ReservationRepository(RestaurantReservationDbContext context) 
        { 
            _context = context;
        }
        public async Task<int> CreateReservation(Reservations reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }
        public async Task<Reservations> GetReservations(int reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId);
        }
        public async Task DeleteReservation(int reservationId)
        {
            var reservation = await GetReservations(reservationId);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateReservation(Reservations updateReservation)
        {
            _context.Reservations.Update(updateReservation);
            await _context.SaveChangesAsync();
        }
    }
}
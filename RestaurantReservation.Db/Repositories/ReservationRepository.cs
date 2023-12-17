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
            if (!await ResevationExists(updateReservation.Id))
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

        public async Task<bool> ResevationExists(int reservationId)
        {
            return await _context.Reservations.AnyAsync(reservation => reservation.Id == reservationId);
        }

        public async Task<List<Orders>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            var orderList = await _context.Orders
                .Where(a => a.ReservationsId == reservationId)
                .Include(orderItem => orderItem.OrderItemsId)
                .ThenInclude(menu => menu.MenuItems)
                .ToListAsync();
            return orderList;
        }

        public async Task<List<MenuItems>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var orders = await ListOrdersAndMenuItemsAsync(reservationId);

            var menuItems = orders
                .SelectMany(order => order.OrderItemsId
                .Select(menu => menu.MenuItems))
                .ToList();

            return menuItems;
        }
    }
}
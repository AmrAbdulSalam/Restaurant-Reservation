using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateMenuItemAsync(MenuItems newMenuItem)
        {
            if (newMenuItem == null)
            {
                throw new ArgumentNullException(nameof(newMenuItem));
            }
            await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
            return newMenuItem.Id;
        }

        public async Task<MenuItems> GetMenuItemAsync(int menuItemId)
        {
            return await _context.MenuItems.FindAsync(menuItemId);
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await GetMenuItemAsync(menuItemId);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItems updateMenuItem)
        {
            if (await GetMenuItemAsync(updateMenuItem.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateMenuItem));
            }
            _context.MenuItems.Update(updateMenuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MenuItems>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var repo = new OrderRepository(_context);
            var orders = await repo.ListOrdersAndMenuItemsAsync(reservationId);

            var menuItems = orders
                .SelectMany(order => order.OrderItemsId
                .Select(menu => menu.MenuItems))
                .ToList();

            return menuItems;
        }
    }
}
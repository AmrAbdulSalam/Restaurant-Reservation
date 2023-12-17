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
    }
}
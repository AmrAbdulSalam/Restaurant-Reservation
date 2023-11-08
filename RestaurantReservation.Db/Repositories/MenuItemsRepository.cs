﻿using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemsRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public MenuItemsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateMenuItem(MenuItems newMenuItem)
        {
            await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
            return newMenuItem.Id;
        }
        public async Task<MenuItems> GetMenuItem(int menuItemId)
        {
            return await _context.MenuItems.FindAsync(menuItemId);
        }
        public async Task DeleteMenuItem(int menuItemId)
        {
            var menuItem = await GetMenuItem(menuItemId);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMenuItem(MenuItems updateMenuItem)
        {
            _context.MenuItems.Update(updateMenuItem);
            await _context.SaveChangesAsync();
        }
    }
}
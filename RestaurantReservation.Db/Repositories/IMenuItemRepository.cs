using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        Task<int> CreateMenuItemAsync(MenuItems newMenuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<MenuItems> GetMenuItemAsync(int menuItemId);
        Task UpdateMenuItemAsync(MenuItems updateMenuItem);
    }
}
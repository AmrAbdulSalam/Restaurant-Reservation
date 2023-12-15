using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        /// <summary>
        /// Creating a new Menu Item
        /// </summary>
        /// <param name="newMenuItem">The created Menu Item entity</param>
        /// <returns></returns>
        Task<int> CreateMenuItemAsync(MenuItems newMenuItem);

        /// <summary>
        /// Delete an existing Menu Item
        /// </summary>
        /// <param name="menuItemId">Passing existing customer id</param>
        Task DeleteMenuItemAsync(int menuItemId);

        /// <summary>
        /// Get an existing Menu item
        /// </summary>
        /// <param name="menuItemId">Passing Menu Item Id</param>
        /// <returns>Menu Item object</returns>
        Task<MenuItems> GetMenuItemAsync(int menuItemId);

        /// <summary>
        /// Update an existing Menu item 
        /// </summary>
        /// <param name="updateMenuItem">The created Menu Item entity</param>
        Task UpdateMenuItemAsync(MenuItems updateMenuItem);
    }
}
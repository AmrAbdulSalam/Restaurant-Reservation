using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        /// <summary>
        /// Create a new Table
        /// </summary>
        /// <param name="newTable">The created Table entity</param>
        /// <returns>The new Table Id</returns>
        Task<int> CreateTableAsync(Tables newTable);

        /// <summary>
        /// Delete an existing table
        /// </summary>
        /// <param name="tableId">Passing an existing table id</param>
        Task DeleteTableAsync(int tableId);

        /// <summary>
        /// Get an existing Table
        /// </summary>
        /// <param name="tableId">Passing an existing table id</param>
        /// <returns>Table object</returns>
        Task<Tables> GetTableAsync(int tableId);
        
        /// <summary>
        /// Update an exisitng Table
        /// </summary>
        /// <param name="updateTable">An existing Table entity</param>
        Task UpdateTableAsync(Tables updateTable);
    }
}
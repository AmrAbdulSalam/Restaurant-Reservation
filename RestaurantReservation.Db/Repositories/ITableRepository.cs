using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        Task<int> CreateTableAsync(Tables newTable);
        Task DeleteTableAsync(int tableId);
        Task<Tables> GetTableAsync(int tableId);
        Task UpdateTableAsync(Tables updateTable);
    }
}
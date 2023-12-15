using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateTableAsync(Tables newTable)
        {
            if (newTable == null)
            {
                throw new ArgumentNullException(nameof(newTable));
            }
            await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
            return newTable.Id;
        }
        public async Task<Tables> GetTableAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }
        public async Task DeleteTableAsync(int tableId)
        {
            var table = await GetTableAsync(tableId);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTableAsync(Tables updateTable)
        {
            if (await GetTableAsync(updateTable.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateTable));
            }
            _context.Tables.Update(updateTable);
            await _context.SaveChangesAsync();
        }
    }
}
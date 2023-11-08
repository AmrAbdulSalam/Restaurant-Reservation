using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TablesRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public TablesRepository(RestaurantReservationDbContext context) 
        {
            _context = context;
        }
        public async Task<int> CreateTable(Tables newTable)
        {
            await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
            return newTable.Id;
        }
        public async Task<Tables> GetTable(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }
        public async Task DeleteTable(int tableId)
        {
            var table = await GetTable(tableId);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTable(Tables updateTable)
        {
            _context.Tables.Update(updateTable);
            await _context.SaveChangesAsync();
        }
    }
}
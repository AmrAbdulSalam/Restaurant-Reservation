using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreatingView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW 
                View_ReservationsWithCustomerAndRestaurantInfo
                AS
                SELECT 
	                [dbo].[Reservations].PartySize,
	                [dbo].[Reservations].ReservationDate,
	                [dbo].[Customers].FirstName + ' ' + [dbo].[Customers].LastName AS FullName,
	                [dbo].[Restaurants].Name,
	                [dbo].[Restaurants].Address,
	                [dbo].[Restaurants].OpeningHours
                FROM [dbo].[Reservations]
                INNER JOIN [dbo].[Customers]
                ON [dbo].[Customers].Id = [dbo].[Reservations].CustomersId
                INNER JOIN [dbo].[Restaurants]
                ON [dbo].[Restaurants].Id = [dbo].[Reservations].RestaurantId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW View_ReservationsWithCustomerAndRestaurantInfo");
        }
    }
}
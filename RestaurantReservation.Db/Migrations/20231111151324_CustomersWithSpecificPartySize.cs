using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CustomersWithSpecificPartySize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE PROCEDURE ReservationWithSpecificPartySize
	            @PartySize varchar (10)
                AS
                BEGIN
	                SELECT 
                        [dbo].[Customers].*
	                FROM [dbo].[Reservations]
	                INNER JOIN [dbo].[Customers]
	                ON [dbo].[Reservations].CustomersId = [dbo].[Customers].Id
	                where [dbo].[Reservations].PartySize = @PartySize
                END"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE ReservationWithSpecificPartySize");
        }
    }
}

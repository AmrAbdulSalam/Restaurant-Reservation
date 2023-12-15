using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class TotalRevenuFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION TotalRevenuBySpecificRestaurant(
	                    @Restaurant_Id INT
                )
                RETURNS INT
                AS 
                BEGIN
	            DECLARE @Total INT;

	            SELECT 
		            @Total = SUM(TotalAmount)
	            FROM [dbo].[Orders]
                INNER JOIN [dbo].[Reservations]
                ON [dbo].[Reservations].Id = [dbo].[Orders].ReservationsId
                GROUP BY RestaurantId
                HAVING RestaurantId = @Restaurant_Id
                RETURN @Total
                END"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION TotalRevenuBySpecificRestaurant");
        }
    }
}
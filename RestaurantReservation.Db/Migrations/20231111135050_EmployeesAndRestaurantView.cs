using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesAndRestaurantView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW View_EmployeesWithRespectiveRestaurant
                AS
                SELECT 
	                [dbo].[Employees].FirstName + ' ' + [dbo].[Employees].LastName AS FullName,
	                [dbo].[Employees].Position,
	                [dbo].[Restaurants].Name,
	                [dbo].[Restaurants].Address,
	                [dbo].[Restaurants].OpeningHours
                FROM [dbo].[Employees]
                INNER JOIN [dbo].[Restaurants]
                ON [dbo].[Employees].RestaurantsId = [dbo].[Restaurants].Id"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW View_EmployeesWithRespectiveRestaurant");
        }
    }
}
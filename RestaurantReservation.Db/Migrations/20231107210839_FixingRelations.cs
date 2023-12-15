using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Reservations_ReservationsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Orders_OrdersId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_OrderItems_OrderItemsId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItemsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Orders_OrdersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Employees_EmployeesId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_MenuItems_MenuItemsId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Reservations_ReservationsId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Tables_TablesId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reservations_ReservationsId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_EmployeesId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_MenuItemsId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ReservationsId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_TablesId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ReservationsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuItemsId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TablesId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "Tables",
                newName: "RestaurantsId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_ReservationsId",
                table: "Tables",
                newName: "IX_Tables_RestaurantsId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Reservations",
                newName: "TablesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_OrdersId",
                table: "Reservations",
                newName: "IX_Reservations_TablesId");

            migrationBuilder.RenameColumn(
                name: "OrderItemsId",
                table: "Orders",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderItemsId",
                table: "Orders",
                newName: "IX_Orders_ReservationsId");

            migrationBuilder.RenameColumn(
                name: "OrderItemsId",
                table: "MenuItems",
                newName: "RestaurantsId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_OrderItemsId",
                table: "MenuItems",
                newName: "IX_MenuItems_RestaurantsId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Employees",
                newName: "RestaurantsId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_OrdersId",
                table: "Employees",
                newName: "IX_Employees_RestaurantsId");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantsId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemsId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomersId",
                table: "Reservations",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantsId",
                table: "Reservations",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeesId",
                table: "Orders",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemsId",
                table: "OrderItems",
                column: "MenuItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersId",
                table: "OrderItems",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Restaurants_RestaurantsId",
                table: "Employees",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantsId",
                table: "MenuItems",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemsId",
                table: "OrderItems",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrdersId",
                table: "OrderItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeesId",
                table: "Orders",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reservations_ReservationsId",
                table: "Orders",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomersId",
                table: "Reservations",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantsId",
                table: "Reservations",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TablesId",
                table: "Reservations",
                column: "TablesId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantsId",
                table: "Tables",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Restaurants_RestaurantsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantsId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemsId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrdersId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeesId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reservations_ReservationsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantsId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TablesId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantsId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomersId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EmployeesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemsId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrdersId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RestaurantsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuItemsId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "Tables",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_RestaurantsId",
                table: "Tables",
                newName: "IX_Tables_ReservationsId");

            migrationBuilder.RenameColumn(
                name: "TablesId",
                table: "Reservations",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TablesId",
                table: "Reservations",
                newName: "IX_Reservations_OrdersId");

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "Orders",
                newName: "OrderItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ReservationsId",
                table: "Orders",
                newName: "IX_Orders_OrderItemsId");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "MenuItems",
                newName: "OrderItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_RestaurantsId",
                table: "MenuItems",
                newName: "IX_MenuItems_OrderItemsId");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "Employees",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RestaurantsId",
                table: "Employees",
                newName: "IX_Employees_OrdersId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemsId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TablesId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_EmployeesId",
                table: "Restaurants",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuItemsId",
                table: "Restaurants",
                column: "MenuItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ReservationsId",
                table: "Restaurants",
                column: "ReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_TablesId",
                table: "Restaurants",
                column: "TablesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ReservationsId",
                table: "Customers",
                column: "ReservationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Reservations_ReservationsId",
                table: "Customers",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Orders_OrdersId",
                table: "Employees",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_OrderItems_OrderItemsId",
                table: "MenuItems",
                column: "OrderItemsId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItemsId",
                table: "Orders",
                column: "OrderItemsId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Orders_OrdersId",
                table: "Reservations",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Employees_EmployeesId",
                table: "Restaurants",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_MenuItems_MenuItemsId",
                table: "Restaurants",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Reservations_ReservationsId",
                table: "Restaurants",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Tables_TablesId",
                table: "Restaurants",
                column: "TablesId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reservations_ReservationsId",
                table: "Tables",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}

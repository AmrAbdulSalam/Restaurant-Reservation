using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation
{
    public class Program
    {
        static async Task Main()
        {
            //   ---------------------------> Customer Repository <---------------------------

            //Get Customer by ID
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new CustomerRepository(context);
                var customer = await repo.GetCustomerAsync(2);
                var printCustomer = $"Id={customer.Id} , Name={customer.FirstName} {customer.LastName}";
                Console.WriteLine(printCustomer);
            }

            //Create New Customer
            using (var context = new RestaurantReservationDbContext())
            {
                var newCustomer = new Customers()
                {
                    FirstName = "Rami",
                    LastName = "Waza",
                    Email = "rami123@gmail.com",
                    PhoneNumber = "0599888811"
                };
                var repo = new CustomerRepository(context);
                var id = await repo.CreateCustomerAsync(newCustomer);
                Console.WriteLine(id);
            }

            //Delete Customer
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new CustomerRepository(context);
                await repo.DeleteCustomerAsync(9);
            }

            //Update Customer
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new CustomerRepository(context);
                var customer = await repo.GetCustomerAsync(3);
                customer.FirstName = "Hello";
                customer.Email = "hellp@gmail.com";
                await repo.UpdateCustomerAsync(customer);
            }


            //   ---------------------------> Reservation Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var reservation = new Reservations()
                {
                    ReservationDate = DateTime.Now,
                    PartySize = "Large",
                    TablesId = 2,
                    CustomersId = 2,
                    RestaurantsId = 2
                };
                var repo = new ReservationRepository(context);
                var id = await repo.CreateReservationAsync(reservation);
                Console.WriteLine(id);
                var getReservation = await repo.GetReservationsAsync(id);
                getReservation.PartySize = "Small";
                getReservation.RestaurantsId = 5;
                await repo.UpdateReservationAsync(getReservation);

                await repo.DeleteReservationAsync(id);
            }

            //   ---------------------------> Tables Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var table = new Tables()
                {
                    Capacity = "55",
                    RestaurantsId = 1,
                };
                var repo = new TableRepository(context);
                var id = await repo.CreateTableAsync(table);
                Console.WriteLine(id);
                var getReservation = await repo.GetTableAsync(id);
                getReservation.Capacity = "10";
                getReservation.RestaurantsId = 5;
                await repo.UpdateTableAsync(getReservation);

                await repo.DeleteTableAsync(id);
            }

            //   ---------------------------> Orders Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var order = new Orders()
                {
                    OrderDate = DateTime.Now,
                    TotalAmount = 999.99,
                    ReservationsId = 1,
                    EmployeesId = 1,
                };
                var repo = new OrderRepository(context);
                var id = await repo.CreateOrderAsync(order);
                Console.WriteLine(id);
                var value = await repo.GetOrderAsync(id);
                value.TotalAmount = 2000.99;
                value.ReservationsId = 5;
                await repo.UpdateOrderAsync(value);

                await repo.DeleteOrderAsync(id);
            }

            //   ---------------------------> Employyes Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var employee = new Employees()
                {
                    FirstName = "Emplo1",
                    LastName = "test",
                    Position = "Maanager",
                    RestaurantsId = 1,
                };
                var repo = new EmployeeRepository(context);
                var id = await repo.CreateEmployeeAsync(employee);
                Console.WriteLine(id);
                var value = await repo.GetEmployeeAsync(id);
                value.LastName = "Helmi";
                await repo.UpdateEmployeeAsync(value);

                await repo.DeleteEmployeeAsync(id);
            }

            //   ---------------------------> Restaurants Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var restaurant = new Restaurants()
                {
                    Name = "Shawermaa1",
                    Address = "Ramllah",
                    PhoneNumber = "0599111111",
                    OpeningHours = "9:00AM-1:00PM"
                };
                var repo = new RestaurantRepository(context);
                var id = await repo.CreateRestaurantAsync(restaurant);
                Console.WriteLine(id);
                var value = await repo.GetRestaurantAsync(id);
                value.Address = "Hebron";
                await repo.UpdateRestaurantAsync(value);

                await repo.DeleteRestaurantAsync(id);
            }

            //   ---------------------------> OrderItems Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var orderItem = new OrderItems()
                {
                    Quantity = 77,
                    MenuItemsId = 1,
                    OrdersId = 9
                };
                var repo = new OrderItemRepository(context);
                var id = await repo.CreateOrderItemAsync(orderItem);
                Console.WriteLine(id);
                var value = await repo.GetOrderItemAsync(id);
                value.Quantity = 22;
                await repo.UpdateOrderItemAsync(value);

                await repo.DeleteOrderItemAsync(id);
            }

            //   ---------------------------> MenuItems Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var menuItem = new MenuItems()
                {
                    Name = "Meat crispy",
                    Description = "Best food",
                    Price = 55.5,
                    RestaurantsId = 1
                };
                var repo = new MenuItemRepository(context);
                var id = await repo.CreateMenuItemAsync(menuItem);
                Console.WriteLine(id);
                var value = await repo.GetMenuItemAsync(id);
                value.Price = 22.2;
                await repo.UpdateMenuItemAsync(value);

                await repo.DeleteMenuItemAsync(id);
            }

            //Task 10 (A)  --> ListManagers()
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new EmployeeRepository(context);
                var manageers = await repo.ListManagersAsync();
                foreach (var manger in manageers)
                {
                    Console.WriteLine($"Name={manger.FirstName} {manger.LastName}");
                }
            }
            //Task 10 (B) --> Reservation List by Customer ID
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new ReservationRepository(context);
                var reservations = await repo.GetReservationsByCustomerAsync(1);
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Date={reservation.ReservationDate} , Size = {reservation.PartySize}");
                }
            }
            //Task 10 (C) --> List Orders And Menu Items
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new OrderRepository(context);
                var orders = await repo.ListOrdersAndMenuItemsAsync(1);
                foreach (var order in orders)
                {
                    Console.WriteLine($"OrderAmount={order.TotalAmount} , OrderDate={order.OrderDate}");
                    foreach (var item in order.OrderItemsId)
                    {
                        Console.WriteLine($"Quantity = {item.Quantity}\n" +
                            $"Name = {item.MenuItems.Name}\n" +
                            $"Description = {item.MenuItems.Description}"
                        );
                    }
                    Console.WriteLine("*****");
                }
            }
            //Task 10 (D) --> List Orders Menu
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new MenuItemRepository(context);
                var menus = await repo.ListOrderedMenuItemsAsync(2);

                foreach (var menu in menus)
                {
                    Console.WriteLine($"Name={menu.Name} , Description={menu.Description}");
                }
            }

            //Task 10 (C) --> Average total amount for each employee
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new OrderRepository(context);
                var average = repo.CalculateAverageOrderAmount(1);
                Console.WriteLine($"Average is {average}");

            }

            //Task 11 (1) Reservation With Customer and Restaurant Information
            using (var context = new RestaurantReservationDbContext())
            {
                var resrvations = await context.View_ReservationsWithCustomerAndRestaurantInfo.ToListAsync();
                foreach (var resrvation in resrvations)
                {
                    Console.WriteLine(
                        $"PartySize={resrvation.PartySize} , For={resrvation.FullName}" +
                        $"RestaurantName={resrvation.Name} , OpeningTime={resrvation.OpeningHours}"
                        );
                }
            }

            //Task 11 (2) Employees with thier respective restaurant info
            using (var context = new RestaurantReservationDbContext())
            {
                var employees = await context.View_EmployeesWithRespectiveRestaurant.ToListAsync();
                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        $"PartySize={employee.Position} , For={employee.FullName}" +
                        $"RestaurantName={employee.Name} , OpeningTime={employee.OpeningHours}"
                        );
                }
            }
            //Task 12 Create DataBase Function to calculate total revenu
            using (var context = new RestaurantReservationDbContext())
            {
                var restaurantId = 1;
                var restaurantRepo = new RestaurantRepository(context);
                var restaurantService = new RestaurantService(context);
                var value = restaurantService.CalculateTotalRevenure(restaurantId);
                Console.WriteLine($"Total={value} by restaurant = {restaurantId}");
            }
            //Task 13 Using Procedure
            using (var context = new RestaurantReservationDbContext())
            {
                Console.WriteLine("test");
                var cutomerRepo = new CustomerRepository(context);
                var customerService = new CustomerService(context);
                var customers = await customerService.CustomersWithSpecificReservationPartySize("small");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Name={customer.FirstName} ");
                }
            }
        }
    }
}
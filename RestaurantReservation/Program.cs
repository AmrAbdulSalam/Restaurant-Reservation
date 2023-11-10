using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

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
                var repo = new CustomersRepository(context);
                var customer = await repo.GetCustomer(6);
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
                var repo = new CustomersRepository(context);
                var id = await repo.CreateCustomer(newCustomer);
                Console.WriteLine(id);
            }

            //Delete Customer
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new CustomersRepository(context);
                await repo.DeleteCustomer(6);
            }

            //Update Customer
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new CustomersRepository(context);
                var customer = await repo.GetCustomer(7);
                customer.FirstName = "Hello";
                customer.Email = "hellp@gmail.com";
                await repo.UpdateCustomer(customer);
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
                var id = await repo.CreateReservation(reservation);
                Console.WriteLine(id);
                var getReservation = await repo.GetReservations(id);
                getReservation.PartySize = "Small";
                getReservation.RestaurantsId = 5;
                await repo.UpdateReservation(getReservation);

                await repo.DeleteReservation(id);
            }

            //   ---------------------------> Tables Repository <---------------------------
            using (var context = new RestaurantReservationDbContext())
            {
                var table = new Tables()
                {
                    Capacity = "55",
                    RestaurantsId = 1,
                };
                var repo = new TablesRepository(context);
                var id = await repo.CreateTable(table);
                Console.WriteLine(id);
                var getReservation = await repo.GetTable(id);
                getReservation.Capacity = "10";
                getReservation.RestaurantsId = 5;
                await repo.UpdateTable(getReservation);

                await repo.DeleteTable(id);
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
                var repo = new OrdersRepository(context);
                var id = await repo.CreateOrder(order);
                Console.WriteLine(id);
                var value = await repo.GetOrder(id);
                value.TotalAmount = 2000.99;
                value.ReservationsId = 5;
                await repo.UpdateOrder(value);

                await repo.DeleteOrder(id);
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
                var repo = new EmployeesRepository(context);
                var id = await repo.CreateEmployee(employee);
                Console.WriteLine(id);
                var value = await repo.GetEmployee(id);
                value.LastName = "Helmi";
                await repo.UpdateEmployee(value);

                await repo.DeleteEmployee(id);
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
                var repo = new RestaurantsRepository(context);
                var id = await repo.CreateRestaurant(restaurant);
                Console.WriteLine(id);
                var value = await repo.GetRestaurant(id);
                value.Address = "Hebron";
                await repo.UpdateRestaurant(value);

                await repo.DeleteRestaurant(id);
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
                var repo = new OrderItemsRepository(context);
                var id = await repo.CreateOrderItem(orderItem);
                Console.WriteLine(id);
                var value = await repo.GetOrderItem(id);
                value.Quantity = 22;
                await repo.UpdateOrderItem(value);

                await repo.DeleteOrderItem(id);
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
                var repo = new MenuItemsRepository(context);
                var id = await repo.CreateMenuItem(menuItem);
                Console.WriteLine(id);
                var value = await repo.GetMenuItem(id);
                value.Price = 22.2;
                await repo.UpdateMenuItem(value);

                await repo.DeleteMenuItem(id);
            }

            //Task 10 (A)  --> ListManagers()
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new EmployeesRepository(context);
                var manageers = await repo.ListManagers();
                foreach (var manger in manageers)
                {
                    Console.WriteLine($"Name={manger.FirstName} {manger.LastName}");
                }
            }
            //Task 10 (B) --> Reservation List by Customer ID
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new ReservationRepository(context);
                var reservations = await repo.GetReservationsByCustomer(1);
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Date={reservation.ReservationDate} , Size = {reservation.PartySize}");
                }
            }
            //Task 10 (C) --> List Orders And Menu Items
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new OrdersRepository(context);
                var orders = await repo.ListOrdersAndMenuItems(1);
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
                var repo = new MenuItemsRepository(context);
                var menus = await repo.ListOrderedMenuItems(2);

                foreach (var menu in menus)
                {
                    Console.WriteLine($"Name={menu.Name} , Description={menu.Description}");
                }
            }

            //Task 10 (C) --> Average total amount for each employee
            using (var context = new RestaurantReservationDbContext())
            {
                var repo = new OrdersRepository(context);
                var average = repo.CalculateAverageOrderAmount(1);
                Console.WriteLine($"Average is {average}");

            }
        }
    }
}
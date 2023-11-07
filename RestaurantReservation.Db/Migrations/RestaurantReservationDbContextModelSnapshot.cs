﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MenuItemsId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemsId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationsId")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("ReservationsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int");

                    b.Property<string>("PartySize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.Property<int?>("TablesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("RestaurantsId");

                    b.HasIndex("TablesId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Tables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employees", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurants", null)
                        .WithMany("EmployeeId")
                        .HasForeignKey("RestaurantsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItems", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurants", null)
                        .WithMany("MenuItemsId")
                        .HasForeignKey("RestaurantsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItems", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.MenuItems", null)
                        .WithMany("OrderItemsId")
                        .HasForeignKey("MenuItemsId");

                    b.HasOne("RestaurantReservation.Db.Models.Orders", null)
                        .WithMany("OrderItemsId")
                        .HasForeignKey("OrdersId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Orders", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Employees", null)
                        .WithMany("OrderId")
                        .HasForeignKey("EmployeesId");

                    b.HasOne("RestaurantReservation.Db.Models.Reservations", null)
                        .WithMany("OrderId")
                        .HasForeignKey("ReservationsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservations", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Customers", null)
                        .WithMany("ReservationId")
                        .HasForeignKey("CustomersId");

                    b.HasOne("RestaurantReservation.Db.Models.Restaurants", null)
                        .WithMany("ReservationId")
                        .HasForeignKey("RestaurantsId");

                    b.HasOne("RestaurantReservation.Db.Models.Tables", null)
                        .WithMany("ReservationId")
                        .HasForeignKey("TablesId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Tables", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurants", null)
                        .WithMany("TableId")
                        .HasForeignKey("RestaurantsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customers", b =>
                {
                    b.Navigation("ReservationId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employees", b =>
                {
                    b.Navigation("OrderId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItems", b =>
                {
                    b.Navigation("OrderItemsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Orders", b =>
                {
                    b.Navigation("OrderItemsId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservations", b =>
                {
                    b.Navigation("OrderId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurants", b =>
                {
                    b.Navigation("EmployeeId");

                    b.Navigation("MenuItemsId");

                    b.Navigation("ReservationId");

                    b.Navigation("TableId");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Tables", b =>
                {
                    b.Navigation("ReservationId");
                });
#pragma warning restore 612, 618
        }
    }
}

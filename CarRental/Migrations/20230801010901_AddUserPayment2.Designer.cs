﻿// <auto-generated />
using System;
using CarRental.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarRental.Migrations
{
    [DbContext(typeof(CarRentingDbContext))]
    [Migration("20230801010901_AddUserPayment2")]
    partial class AddUserPayment2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRental.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("firstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("lastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("\"NormalizedUserName\" IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.Brand", b =>
                {
                    b.Property<string>("BrandId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("country")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarRental.Models.Car", b =>
                {
                    b.Property<string>("CarId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("BrandId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CurrentLocation")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("VehicleTypeId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<bool>("availability")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("color")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("image")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("model")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("plateNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("year")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRental.Models.Car_CarFeature", b =>
                {
                    b.Property<string>("CarId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CarFeatureId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("CarId", "CarFeatureId");

                    b.HasIndex("CarFeatureId");

                    b.ToTable("Car_CarFeatures");
                });

            modelBuilder.Entity("CarRental.Models.CarFeature", b =>
                {
                    b.Property<string>("CarFeatureId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("featureName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CarFeatureId");

                    b.ToTable("CarFeatures");
                });

            modelBuilder.Entity("CarRental.Models.Payment", b =>
                {
                    b.Property<string>("PaymentId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ReservationId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<decimal>("amount")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("paymentMethod")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("paymentStatus")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PaymentId");

                    b.HasIndex("ReservationId")
                        .IsUnique()
                        .HasFilter("\"ReservationId\" IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CarRental.Models.Reservation", b =>
                {
                    b.Property<string>("ReservationId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CarId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("cancellationReason")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("endDate")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("endLocation")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("isConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("startDate")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("startLocation")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("status")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("ReservationId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarRental.Models.UserPayment", b =>
                {
                    b.Property<string>("UserPaymentId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("amount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("cardName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("cardNumber")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("cvv")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("expMonth")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("expYear")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("UserPaymentId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("\"UserId\" IS NOT NULL");

                    b.ToTable("UserPayments");
                });

            modelBuilder.Entity("CarRental.Models.VehicleType", b =>
                {
                    b.Property<string>("VehicleTypeId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("capacity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("fuelType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("mileage")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("transmissionType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("typeName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("vehicleClass")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("\"NormalizedName\" IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Value")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.Car", b =>
                {
                    b.HasOne("CarRental.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarRental.Models.VehicleType", "VehicleType")
                        .WithMany("Cars")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Brand");

                    b.Navigation("User");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("CarRental.Models.Car_CarFeature", b =>
                {
                    b.HasOne("CarRental.Models.CarFeature", "CarFeature")
                        .WithMany("Cars")
                        .HasForeignKey("CarFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Models.Car", "Car")
                        .WithMany("CarFeatures")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("CarFeature");
                });

            modelBuilder.Entity("CarRental.Models.Payment", b =>
                {
                    b.HasOne("CarRental.Models.Reservation", "Reservation")
                        .WithOne("Payment")
                        .HasForeignKey("CarRental.Models.Payment", "ReservationId");

                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Reservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.Reservation", b =>
                {
                    b.HasOne("CarRental.Models.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId");

                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.UserPayment", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithOne("UserPayment")
                        .HasForeignKey("CarRental.Models.UserPayment", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Payments");

                    b.Navigation("Reservations");

                    b.Navigation("UserPayment");
                });

            modelBuilder.Entity("CarRental.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRental.Models.Car", b =>
                {
                    b.Navigation("CarFeatures");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CarRental.Models.CarFeature", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRental.Models.Reservation", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("CarRental.Models.VehicleType", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using BookingService.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingService.Data.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20210607151532_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingService.Data.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("Payment")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingEnd = new DateTime(2021, 6, 9, 20, 15, 32, 67, DateTimeKind.Local).AddTicks(9052),
                            BookingStart = new DateTime(2021, 6, 7, 20, 15, 32, 68, DateTimeKind.Local).AddTicks(7100),
                            CarId = 1,
                            IsCompleted = false,
                            Payment = 75.0
                        });
                });

            modelBuilder.Entity("BookingService.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 30.0,
                            LicensePlate = "A1",
                            Make = "Honda",
                            Model = "City",
                            Year = "2020"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 80.0,
                            LicensePlate = "A2",
                            Make = "Nissan",
                            Model = "GTR",
                            Year = "2008"
                        });
                });

            modelBuilder.Entity("BookingService.Data.Models.Booking", b =>
                {
                    b.HasOne("BookingService.Data.Models.Car", "Car")
                        .WithMany("Bookings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

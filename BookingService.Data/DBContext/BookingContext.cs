using System;
using System.Collections.Generic;
using System.Text;
using BookingService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data.DBContext
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    LicensePlate = "A1",
                    Make = "Honda",
                    Model = "City",
                    Year = "2020",
                    BasePrice = 30,

                },
                new Car
                {
                    Id = 2,
                    LicensePlate = "A2",
                    Make = "Nissan",
                    Model = "GTR",
                    Year = "2008",
                    BasePrice = 80,

                }
            );


            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                  CarId = 1,
                  BookingEnd = DateTime.Now.AddDays(2),
                  BookingStart = DateTime.Now,
                  Id = 1,
                  IsCompleted = false,
                  Payment = 75


                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PricingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingService.Data.DBContext
{
    public class PricingContext : DbContext
    {
        public PricingContext(DbContextOptions<PricingContext> options)
              : base(options)
        {

        }

        public virtual DbSet<Car> Cars { get; set; }

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
        }
    }
}

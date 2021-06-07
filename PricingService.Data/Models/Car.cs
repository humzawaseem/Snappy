using PricingService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingService.Data.Models
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double BasePrice { get; set; }
      
    }
}

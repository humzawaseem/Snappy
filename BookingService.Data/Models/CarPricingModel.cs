using System;
using System.Collections.Generic;
using System.Text;

namespace BookingService.Data.Models
{
    public class CarPricingModel
    {

        public double BasePrice { get; set; }
        public double Discount { get; set; }
        public double Insurance { get; set; }
        public double SnapcarFee { get; set; }
        public double PeakFare { get; set; }

        public double RentalPrice { get; set; }
    }
}

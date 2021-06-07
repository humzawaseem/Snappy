using System;
using System.Collections.Generic;
using System.Text;

namespace PricingService.Data.Models
{
    public class GetPricingModel
    {

        public int CarId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

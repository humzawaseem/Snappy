using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class BookCarInputDto
    {
        public int CarId { get; set; }
        public DateTime BookingStart { get; set; } = DateTime.Now;
        public DateTime BookingEnd { get; set; } = DateTime.Now.AddDays(2);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BookingService.Data.Repositories;

namespace BookingService.Data.Models
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double Payment { get; set; }

        public bool IsCompleted { get; set; }

        //navigation properties 
        public virtual int CarId { get; set; }
        public virtual Car Car { get; set; }
      
    }
}

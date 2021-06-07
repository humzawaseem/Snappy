using System;
using System.Collections.Generic;
using System.Text;
using BookingService.Data.Repositories;

namespace BookingService.Data.Models
{
    public class Car : IEntity

    {
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public double BasePrice { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
    }
}

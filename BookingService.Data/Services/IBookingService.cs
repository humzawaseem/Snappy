using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingService.Models;

namespace BookingService.Data.Services
{
    public interface IBookingService
    {
        Task<bool> CheckIfCarIsAvailable(int carId);
        Task<bool> GetPricing(int carId, DateTime start, DateTime end);
        Task<ResponseModel> BookCar(int carId, DateTime start, DateTime end);
    }
}

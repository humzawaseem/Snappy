using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookingService.Data.DBContext;
using BookingService.Data.Helpers;
using BookingService.Data.Models;
using BookingService.Data.Repositories;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BookingService.Data.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly BookingContext _context;

        public BookingService(BookingContext context, IRepository<Car> carRepository, IRepository<Booking> bookingRepository)
        {
            _context = context;
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;

           
        }

        public async Task<bool> CheckIfCarIsAvailable(int carId)
        {
            var booking = await _bookingRepository.Get(z => z.CarId == carId && z.IsCompleted == false);
            if (booking == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> GetPricing(int carId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> BookCar(int carId, DateTime start, DateTime end)
        {

            var result = await CheckIfCarIsAvailable(carId);

            if (!result)
            {
                return new ResponseModel
                {
                    Success = false,
                    Error = "Car is already booked"
                };
            }

            var client = new RPCClient();
            var data = await client.CallAsync(carId,start,end);

            return new ResponseModel
            {
                Data = data,
                Success = true
            };
        }
    }
}

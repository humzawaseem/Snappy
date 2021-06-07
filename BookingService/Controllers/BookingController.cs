using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingService.Auth;
using BookingService.Data.Services;
using BookingService.Models;
using Microsoft.AspNetCore.Routing;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("CheckIfCarIsAvailable/{carId}")]
        public async Task<IActionResult> CheckIfCarIsAvailable(int carId)
        {
            var result = await _bookingService.CheckIfCarIsAvailable(carId);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> BookCar([FromBody] BookCarInputDto input)
        {
            
           
                var data  = await _bookingService.BookCar(input.CarId, input.BookingStart, input.BookingEnd);
                return Ok(data);
           

        }
    }
}

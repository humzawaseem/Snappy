using PricingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingService.Data.Services
{
    public interface ICarService
    {
        Task<CarPricingModel> CheckPricing(int carId, DateTime start, DateTime end);
    }
}

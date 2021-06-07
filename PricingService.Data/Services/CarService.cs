using PricingService.Data.DBContext;
using PricingService.Data.Models;
using PricingService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingService.Data.Services
{
    public class CarService : BaseRepository<Car, PricingContext>, ICarService
    {
        public CarService(PricingContext pricingContext) : base(pricingContext)
        {
           
        }

        public async Task<CarPricingModel> CheckPricing(int carId, DateTime start, DateTime end)
        {
            var data = new CarPricingModel();
            try
            {
                var car = await Get(carId);

                data.Insurance = car.BasePrice * 0.1;
                data.SnapcarFee = car.BasePrice * 0.1;

                if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                {
                    data.PeakFare = car.BasePrice + (car.BasePrice * 0.05);
                    data.BasePrice = data.PeakFare;
                }
                else
                {
                    data.BasePrice = car.BasePrice;
                }



                data.RentalPrice = data.BasePrice + data.Insurance + data.SnapcarFee;
                if(end.Subtract(start).Days > 3)
                {
                    data.Discount = 0.15;
                    var discount = data.RentalPrice * data.Discount;
                    data.RentalPrice = data.RentalPrice - discount;
                }

               

            }
            catch(Exception e)
            {
                //log exception
                throw new Exception("Some Error Occured.");
            }

            return data;


        }

    }
}

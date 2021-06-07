using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public string Error { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingSky.RoomBookings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RoomBookings.API.Controllers
{
    [ApiController]
    [Route("/today")]
    public class TodayController : ControllerBase
    {
        private readonly ILogger<TodayController> _logger;

        public TodayController(ILogger<TodayController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IBooking> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new SingleBooking()
            {
                
            })
            .ToArray();
        }
    }
}

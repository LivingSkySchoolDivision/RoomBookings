using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingSky.RoomBookings;
using LivingSky.RoomBookings.Bookings;
using LivingSky.RoomBookings.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RoomBookings.API.Controllers
{
    [ApiController]
    [Route("/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRepository<Room> roomRepository;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(ILogger<RoomsController> logger, IRepository<Room> roomRepository)
        {
            _logger = logger;
            this.roomRepository = roomRepository;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return roomRepository.GetAll();
        }
    }
}

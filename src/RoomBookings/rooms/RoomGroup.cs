using System;

namespace LivingSky.RoomBookings.Rooms
{
    public class RoomGroup : IGUIDable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
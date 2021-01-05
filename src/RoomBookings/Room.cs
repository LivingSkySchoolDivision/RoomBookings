using System;

namespace LivingSky.RoomBookings
{
    public class Room : IGUIDable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
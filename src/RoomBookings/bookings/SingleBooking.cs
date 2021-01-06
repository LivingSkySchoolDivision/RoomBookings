using System;

namespace LivingSky.RoomBookings.Bookings
{
    public class SingleBooking : IBooking, IGUIDable
    {
        public DateTime SeriesStartsDate { get; set; }
        public DateTime SeriesEndsDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ShortDescription { get; set; }
        public string Details { get; set; }
        public string Requestor { get; set; }
        public Guid Id { get; set; }
    }
}
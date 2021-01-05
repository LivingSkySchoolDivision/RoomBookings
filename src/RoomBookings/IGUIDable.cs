using System;
using System.Collections.Generic;
using System.Text;

namespace LivingSky.RoomBookings
{
    public interface IGUIDable
    {
        Guid Id { get; set; }
    }
}
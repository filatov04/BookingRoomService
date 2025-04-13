﻿namespace MeetingRoomBookingService.Entity.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}

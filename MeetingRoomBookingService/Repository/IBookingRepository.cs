﻿using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Repository
{
    public interface IBookingRepository
    {
        Task<Booking?> BookingRoomAsync(Booking booking);
        Task<Booking?> CancellationBookingRoomAsync(Guid IdBooking, Role role);
        Task<bool> IsBookingByDate(Guid id, DateTime start, DateTime end);
    }
}

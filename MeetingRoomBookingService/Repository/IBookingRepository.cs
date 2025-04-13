using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Repository
{
    public interface IBookingRepository
    {
        Task<Booking?> BookingRoomAsync(DateTime time, Guid IdRoom, double BookingTime, Guid UserId, string Description);
        Task<Booking?> CancellationBookingRoomAsync(Guid IdBooking, Role role);
    }
}

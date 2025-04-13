using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Service
{
    public interface IBookingService
    {
        Task<BookingResponseDTO?> BookingRoomAsync(BookingCreateDTO dto);
        Task<BookingResponseDTO?> CancellationBookingRoomAsync(Guid IdBooking, Role role);
    }
}

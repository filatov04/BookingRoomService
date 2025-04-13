using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.DTO
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
        public List<BookingShortDTO> Bookings { get; set; }
    }
}

using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.DTO
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
    }
}

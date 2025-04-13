using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBookingService.Entity.Models
{
    public class Booking
    {
        public Guid Id { get; set; } = new Guid();
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }
        public User UserEntity { get; set; }
        public Room RoomEntity { get; set; }
    }
}

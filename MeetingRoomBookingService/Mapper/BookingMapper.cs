using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Mapper
{
    public class BookingMapper
    {
        public static BookingResponseDTO BookingToDTO(Booking booking)
        {
            return new BookingResponseDTO
            {
                Id = booking.Id,
                StartBooking = booking.StartBooking,
                EndBooking = booking.EndBooking,
                Description = booking.Description,
                Room = new RoomShortDTO
                {
                    Id = booking.RoomEntity.Id,
                    Name = booking.RoomEntity.Name,
                },
                User = new UserShortDTO
                {
                    Id = booking.UserEntity.Id,
                    Name = booking.UserEntity.Name,
                }
            };
        }

        public static Booking BookingToEntity(BookingCreateDTO booking)
        {
            return new Booking
            {
                RoomId = booking.RoomId,
                UserId = booking.UserID,
                Description = booking.Decription,
                StartBooking = booking.StartBooking,
                EndBooking = booking.EndBooking,
            };
        }
    }
}

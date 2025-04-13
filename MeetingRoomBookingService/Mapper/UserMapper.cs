using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Mapper
{
    public class UserMapper
    {
        public static UserResponseDTO UserToDTO(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserRole = user.UserRole,
                Bookings = user.Bookings?.Select(u => new BookingShortDTO
                {
                    Id = u.Id,
                    Description = u.Description,
                    StartBooking = u.StartBooking,
                    EndBooking = u.EndBooking,
                }).ToList() ?? new List<BookingShortDTO>()
            };
        }

        public static User UserToEntity(UserCreateDTO user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                UserRole = user.UserRole,
            };
        }
    }
}

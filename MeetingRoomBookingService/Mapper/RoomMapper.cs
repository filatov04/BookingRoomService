using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Mapper
{
    public class RoomMapper
    {
        public static RoomResponseDTO RoomToDTO(Room room)
        {
            return new RoomResponseDTO
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Bookings = room.Bookings.Select(u => new BookingShortDTO
                {
                    Id =u.Id,
                    Description = u.Description,
                    StartBooking = u.StartBooking,
                    EndBooking = u.EndBooking,
                }).ToList()
            };
        }

        public static Room RoomToEntity (RoomCreateDTO room)
        {
            return new Room
            {
                Name = room.Name,
                Capacity = room.Capacity,
            };
        } 
    }
}

using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoomAsync();
        Task<List<Room>> GetAllFilteredRoomAsync(int capacity = 5);
        Task<List<Room>> GetAllFilteredRoomByDateAsync(DateTime time);
        Task<Room?> AddRoomAsync(Room room, Role role);
        Task<Room?> EditRoomAsync(Room room, Role role, Guid Id);

    }
}

using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Service
{
    public interface IRoomService
    {
        Task<List<RoomResponseDTO>> GetAllRoomAsync(CancellationToken ct = default);
        Task<List<RoomResponseDTO>> GetAllFilteredRoomAsync(int capacity = 5);
        Task<List<RoomResponseDTO>> GetAllFilteredRoomByDateAsync(DateTime date);
        Task<RoomResponseDTO?> AddRoomAsync(RoomCreateDTO room, Role role);
        Task<RoomResponseDTO?> EditRoomAsync(RoomCreateDTO room, Role role, Guid Id);
    }
}

using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;
using MeetingRoomBookingService.Mapper;
using MeetingRoomBookingService.Repository;

namespace MeetingRoomBookingService.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository) => _roomRepository = roomRepository;

        public async Task<List<RoomResponseDTO>> GetAllRoomAsync(CancellationToken ct = default)
        {
            var AllRoomAsync = await _roomRepository.GetAllRoomAsync();
            return AllRoomAsync.Select(RoomMapper.RoomToDTO).ToList();
        }

        public async Task<List<RoomResponseDTO>> GetAllFilteredRoomAsync(int capacity = 5)
        {
            var AllFilteredRoomAsync = await _roomRepository.GetAllFilteredRoomAsync(capacity);
            return AllFilteredRoomAsync.Select(RoomMapper.RoomToDTO).ToList();
        }

        public async Task<List<RoomResponseDTO>> GetAllFilteredRoomByDateAsync(DateTime date)
        {
            var AllFilteredRoomByDate = await _roomRepository.GetAllFilteredRoomByDateAsync(date);
            return AllFilteredRoomByDate.Select(RoomMapper.RoomToDTO).ToList();
        }

        public async Task<RoomResponseDTO?> AddRoomAsync(RoomCreateDTO room, Role role)
        {
           var roomToEntity = RoomMapper.RoomToEntity(room);
           var AddRoom = await _roomRepository.AddRoomAsync(roomToEntity, role);
            return RoomMapper.RoomToDTO(AddRoom);
        }

        public async Task<RoomResponseDTO?> EditRoomAsync(RoomCreateDTO room, Role role, Guid Id)
        {
            var EditRoomToEntity = RoomMapper.RoomToEntity(room);
            var EditRoom = await _roomRepository.EditRoomAsync(EditRoomToEntity, role, Id);
            return EditRoom == null ? null : RoomMapper.RoomToDTO(EditRoom);
        }
    }
}

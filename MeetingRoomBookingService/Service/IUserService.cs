using MeetingRoomBookingService.DTO;

namespace MeetingRoomBookingService.Service
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUserBookingAsync();
    }
}

using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Mapper;
using MeetingRoomBookingService.Repository;

namespace MeetingRoomBookingService.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<List<UserResponseDTO>> GetAllUserBookingAsync()
        {
            var AllUserBooking = await _userRepository.GetAllUserBookingAsync();
            return AllUserBooking.Select(UserMapper.UserToDTO).ToList();
        }
    }
}

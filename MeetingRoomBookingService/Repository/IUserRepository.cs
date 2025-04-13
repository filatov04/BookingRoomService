using MeetingRoomBookingService.Entity.Models;

namespace MeetingRoomBookingService.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserBookingAsync();
    }

}

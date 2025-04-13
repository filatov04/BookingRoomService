using MeetingRoomBookingService.DB;
using MeetingRoomBookingService.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<List<User>> GetAllUserBookingAsync()
        {
            return await _context.Users
                .Include(u => u.Bookings)
                .Where(u => u.Bookings.Any())
                .ToListAsync();
        }
    }
}

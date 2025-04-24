using MeetingRoomBookingService.DB;
using MeetingRoomBookingService.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingService.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Room>> GetAllRoomAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<List<Room>> GetAllFilteredRoomAsync(int capacity = 5)
        {
            return await _context.Rooms.Where(u => u.Capacity > capacity).ToListAsync();
        }

        public async Task<List<Room>> GetAllFilteredRoomByDateAsync(DateTime time)
        {
            return await _context.Rooms
                .Include(u => u.Bookings)
                .Where(u => u.Bookings.Any(booking => booking.StartBooking < time || booking.EndBooking > time))
                .ToListAsync();
        }

        public async Task<Room?> AddRoomAsync(Room room, Role role)
        {
            if (role >= Role.SeniorSpecialist)
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room;
            }
            return null;

        }

        public async Task<Room?> EditRoomAsync(Room room, Role role, Guid Id)
        {
            if (role >= Role.SeniorSpecialist)
            {
                var item = await _context.Rooms.FirstOrDefaultAsync(t => t.Id == Id);
                item.Name = room.Name;
                item.Capacity = room.Capacity;
                await _context.SaveChangesAsync();
                return room;
            }
            return null;
        }

    }

    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

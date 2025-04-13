using MeetingRoomBookingService.DB;
using MeetingRoomBookingService.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context) => _context = context;

        public async Task<Booking?> BookingRoomAsync(DateTime time, Guid IdRoom, double BookingTime, Guid UserId, string Description)
        {
            DateTime EndBookingTime = time.AddHours(BookingTime);
            if (BookingTime > 3) return null;
            if (time < DateTime.Now) return null;
            bool IsAvailable = await _context.Bookings
                .AnyAsync(b => b.RoomEntity.Id == IdRoom && b.StartBooking > EndBookingTime && b.EndBooking < time);

            if (IsAvailable)
            {
                Booking newBooking = new Booking {
                    RoomId = IdRoom,
                    StartBooking = time,
                    EndBooking = EndBookingTime,
                    UserId = UserId,
                    Description = Description
                };

                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();
                return newBooking;
            }


            return null;

        }

        public async Task<Booking?> CancellationBookingRoomAsync(Guid IdBooking, Role role)
        {
            if(role < Role.SeniorSpecialist)  return null;
            var RemoveBooking = await _context.Bookings.FirstOrDefaultAsync(b => IdBooking == b.Id);
            if (RemoveBooking != null)
            {
                _context.Bookings.Remove(RemoveBooking);
                await _context.SaveChangesAsync();
                return RemoveBooking;
            }

            return null;
        }

    }
}

using MeetingRoomBookingService.DB;
using MeetingRoomBookingService.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context) => _context = context;

        public async Task<Booking?> BookingRoomAsync(Booking booking)
        { 
            if ((booking.EndBooking - booking.StartBooking).TotalHours > 3) return null;
            if (booking.StartBooking < DateTime.Now) return null;
            bool IsAvailable = await _context.Bookings
                .AnyAsync(b => b.RoomEntity.Id == booking.RoomId && b.StartBooking > booking.EndBooking && b.EndBooking < booking.StartBooking);

            if (IsAvailable)
            {
                Booking newBooking = new Booking {
                    RoomId = booking.RoomId,
                    StartBooking = booking.StartBooking,
                    EndBooking = booking.EndBooking,
                    UserId = booking.UserId,
                    Description = booking.Description
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

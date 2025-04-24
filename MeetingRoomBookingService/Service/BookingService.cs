using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;
using MeetingRoomBookingService.Mapper;
using MeetingRoomBookingService.Repository;

namespace MeetingRoomBookingService.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) => _bookingRepository = bookingRepository;

        public async Task<BookingResponseDTO?> BookingRoomAsync(BookingCreateDTO dto)
        {
            var BookingToEntity = BookingMapper.BookingToEntity(dto);
            if ((dto.EndBooking - dto.StartBooking).TotalHours > 3)
            {
                throw new Exception("Нельзя бронить больше чем на 3 часа");
            }

            if (dto.StartBooking < DateTime.Now) return null;

            var BookingRoom = await _bookingRepository.BookingRoomAsync(BookingToEntity);
            return BookingRoom is not null ? BookingMapper.BookingToDTO(BookingRoom) : null;
        }

        public async Task<BookingResponseDTO?> CancellationBookingRoomAsync(Guid IdBooking, Role role)
        {
            var CancellationBookingRoom = await _bookingRepository.CancellationBookingRoomAsync(IdBooking, role);
            return CancellationBookingRoom == null ? null : BookingMapper.BookingToDTO(CancellationBookingRoom);
        }

    }
}

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
            var BookingRoom = await _bookingRepository.BookingRoomAsync(BookingToEntity);
            return BookingRoom == null ? null : BookingMapper.BookingToDTO(BookingRoom);
        }

        public async Task<BookingResponseDTO?> CancellationBookingRoomAsync(Guid IdBooking, Role role)
        {
            var CancellationBookingRoom = await _bookingRepository.CancellationBookingRoomAsync(IdBooking, role);
            return CancellationBookingRoom == null ? null : BookingMapper.BookingToDTO(CancellationBookingRoom);
        }

    }
}

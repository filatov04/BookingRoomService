using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;
using MeetingRoomBookingService.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService) => _bookingService = bookingService;

        [HttpPost("bookingRoom")]
        public async Task<IActionResult> BookingRoom(BookingCreateDTO dto)
        {
            var bookingRoom = await _bookingService.BookingRoomAsync(dto);
            return bookingRoom == null ? NotFound() : Ok(bookingRoom);
        }

        [HttpDelete("cancellationBooking")]
        public async Task<IActionResult> CancellationBookingRoomAsync(Guid IdBooking, Role role)
        {
            var cancellationRoom = await _bookingService.CancellationBookingRoomAsync(IdBooking, role);
            return cancellationRoom == null ? NotFound() : Ok(cancellationRoom);
        }
    }
}

using MeetingRoomBookingService.Service;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("AllUserBooking")]
        public async Task<IActionResult> GetAllUserBooking()
        {
            var AllUserBooking = await _userService.GetAllUserBookingAsync();
            return Ok(AllUserBooking);
        }
    }
}

using MeetingRoomBookingService.DTO;
using MeetingRoomBookingService.Entity.Models;
using MeetingRoomBookingService.Service;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRoom(CancellationToken ct)
        {
            var AllRoom = await _roomService.GetAllRoomAsync();
            return Ok(AllRoom);
        }

        [HttpGet("filtered/capacity")]
        public async Task<IActionResult> GetAllFilteredRoom(int capacity = 5)
        {
            var AllFilteredRoom = await _roomService.GetAllFilteredRoomAsync(capacity);
            return Ok(AllFilteredRoom);
        }

        [HttpGet("FilteredByDate")]
        public async Task<IActionResult> GetAllFilteredRoomByDate(DateTime date)
        {
            var AllFiltereByDate = await _roomService.GetAllFilteredRoomByDateAsync(date);
            return Ok(AllFiltereByDate);
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom(RoomCreateDTO dto, Role role)
        {
            var AddRoom = await _roomService.AddRoomAsync(dto, role);
            return AddRoom == null ? NotFound() : Ok(AddRoom);

        }

        [HttpPut("EditRoom")]
        public async Task<IActionResult> EditRoom(RoomCreateDTO dto, Role role, Guid Id)
        {
            var edit = await _roomService.EditRoomAsync(dto,role,Id);
            return edit == null ? NotFound() : Ok(edit);
        }
    }
}

namespace MeetingRoomBookingService.DTO
{
    public class BookingCreateDTO
    {
        public Guid RoomId { get; set; }
        public Guid UserID { get; set; }
        public DateTime StartBooking {  get; set; }
        public DateTime EndBooking { get; set; }
        public string? Decription { get; set; }
    }
}
    
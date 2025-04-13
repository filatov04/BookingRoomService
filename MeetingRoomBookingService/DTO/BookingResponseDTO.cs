namespace MeetingRoomBookingService.DTO
{
    public class BookingResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }
        public string? Description { get; set; }
        public RoomShortDTO Room {  get; set; }
        public UserShortDTO User { get; set; }
    }

    public class RoomShortDTO
    {
        public Guid Id { get; set; }
        public string Name {  get; set; }
    }

    public class UserShortDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}

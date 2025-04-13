namespace MeetingRoomBookingService.DTO
{
    public class RoomResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<BookingShortDTO> Bookings { get; set; }
    }

    public class BookingShortDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartBooking { get; set; }
        public DateTime EndBooking { get; set; }

    }
}

namespace MeetingRoomBookingService.Entity.Models
{
    public enum Role
    {
        JuniorSpecialist = 1,
        MiddleSpecialist = 2 ,
        SeniorSpecialist = 3,
        TeamLead = 4 ,
    }

    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }

        public List<Booking> Bookings { get; set; } = new();

    }
}

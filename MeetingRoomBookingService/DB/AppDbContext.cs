using MeetingRoomBookingService.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingService.DB
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.UserEntity)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.RoomEntity)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Room>()
                .Property(u => u.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Booking>()
                .Property(u => u.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}

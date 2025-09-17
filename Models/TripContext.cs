using Microsoft.EntityFrameworkCore;

namespace M8_Project2.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) 
            : base(options) 
        { }

        public DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Portland",
                    StartDate = new DateTime(2023,3,1),
                    EndDate = new DateTime(2024,3,7),
                    Accommodation = "The Benson Hotel",
                    AccommodationPhone = "503-555-1234",
                    AccommodationEmail = "staff@thebenson.com",
                    Activity1 = "Get Voodoo donuts",
                    Activity2 = "Walk in the rain",
                    Activity3 = "Go to Powell's"
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "Boise",
                    StartDate = new DateTime(2023,6,6),
                    EndDate = new DateTime(2023,6,14),
                    Accommodation = "Holiday Inn Express",
                    Activity1 = "Visit family"
                }
            );
        }
    }
}

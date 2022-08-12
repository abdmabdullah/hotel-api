namespace hotel_api.Utilities
{
    using hotel_api.Models;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("HotelDatabase"));
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Facilities)
                .WithMany(h => h.Hotels)
                .UsingEntity<FacilityHotel>(
                x => x
                    .HasOne(f => f.Facility)
                    .WithMany(h => h.FacilityHotels)
                    .HasForeignKey(f => f.FacilityId),
                j => j
                    .HasOne(h => h.Hotel)
                    .WithMany(f => f.FacilityHotels)
                    .HasForeignKey(h => h.Hotel.Id));
        }
    }
}

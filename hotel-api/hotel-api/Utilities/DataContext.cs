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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasGeneratedTsVectorColumn(
                    h => h.SearchVector,
                    "english",
                    h => new { h.Name, h.Description, h.Address, h.Facilities})
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN");
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FilterType> FilterTypes { get; set; }
    }
}

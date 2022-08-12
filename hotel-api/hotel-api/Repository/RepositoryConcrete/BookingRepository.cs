using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;

namespace hotel_api.Repository.RepositoryConcrete
{
    public class BookingRepository : IBookingRepository, IDisposable
    {
        private DataContext _dbContext;
        public BookingRepository(DataContext context)
        {
            _dbContext = context;
        }
        public void AddBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _dbContext.Bookings.ToList();
        }

        public IEnumerable<Booking> GetBookingByHotelId(int hotelId)
        {
            IEnumerable<Booking> bookings = _dbContext.Bookings.Where(x => x.HotelId == hotelId);
            if (bookings == null)
                throw new KeyNotFoundException("No bookings found");
            return bookings;
        }

        public Booking GetBookingById(int id)
        {
            Booking booking = _dbContext.Bookings.Find(id);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found");
            return booking;
        }

        public IEnumerable<Booking> GetBookingsByUser(int userId)
        {
            IEnumerable<Booking> bookings = _dbContext.Bookings.Where(x => x.UserId == userId);
            if (bookings == null)
                throw new KeyNotFoundException("No bookings found against the user");
            return bookings;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

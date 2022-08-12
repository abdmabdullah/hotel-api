namespace hotel_api.Repository.RepositoryInterfaces
{
    using hotel_api.Models;
    public interface IBookingRepository : IDisposable
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        IEnumerable<Booking> GetBookingsByUser(int userId);
        IEnumerable<Booking> GetBookingByHotelId(int hotelId);
        void AddBooking(Booking booking);
    }
}

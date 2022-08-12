using hotel_api.Models;

namespace hotel_api.Repository.RepositoryInterfaces
{
    public interface IHotelRepository : IDisposable
    {
        IEnumerable<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(Hotel hotel);
    }
}

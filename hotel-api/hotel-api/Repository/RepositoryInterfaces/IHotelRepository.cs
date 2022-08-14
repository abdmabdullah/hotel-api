using hotel_api.ApiModels;
using hotel_api.Models;

namespace hotel_api.Repository.RepositoryInterfaces
{
    public interface IHotelRepository : IDisposable
    {
        IEnumerable<Hotel> GetAllHotels();
        HotelDetailsApiModel GetHotelById(int id);
        int AddHotel(HotelApiModel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(Hotel hotel);
        bool IsHotelAvailable(int hotelId, DateTime checkInDate, DateTime checkOutDate);
        void Save();
    }
}

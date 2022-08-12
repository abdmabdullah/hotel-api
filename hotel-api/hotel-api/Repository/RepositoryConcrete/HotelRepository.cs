using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace hotel_api.Repository.RepositoryConcrete
{
    public class HotelRepository : IHotelRepository, IDisposable
    {
        private DataContext _dbContext;
        public HotelRepository(DataContext context)
        {
            _dbContext = context;
        }

        public void AddHotel(Hotel hotel)
        {
            _dbContext.Hotels.Add(hotel);
        }

        public void DeleteHotel(Hotel hotel)
        {
            _dbContext.Hotels.Remove(hotel);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _dbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            Hotel hotel = _dbContext.Hotels.Find(id);
            if (hotel == null)
                throw new KeyNotFoundException("Hotel not found");
            return hotel;
        }

        public void UpdateHotel(Hotel hotel)
        {
            _dbContext.Entry(hotel).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

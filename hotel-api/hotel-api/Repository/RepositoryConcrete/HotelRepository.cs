using hotel_api.ApiModels;
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

        public int AddHotel(HotelApiModel hotel)
        {
            var newHotel = new Hotel
            {
                Name = hotel.Name,
                Description = hotel.Description,
                RatePerNight = hotel.RatePerNight,
                Capacity = hotel.Capacity,
                Address = hotel.Address,
                Facilities = _dbContext.Facilities.Where(x => hotel.FacilityIds.Any(y => y.Equals(x.Id))).ToList()
            };
            
            _dbContext.Hotels.Add(newHotel);
            Save();
            return newHotel.Id;
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

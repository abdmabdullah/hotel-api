using hotel_api.ApiModels;
using hotel_api.Config;
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

        public HotelDetailsApiModel GetHotelById(int id)
        {
            Hotel hotel = _dbContext.Hotels.Find(id);
            if (hotel == null)
                throw new KeyNotFoundException("Hotel not found");
            HotelDetailsApiModel hotelDetails = new HotelDetailsApiModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                Description = hotel.Description,
                RatePerNight = hotel.RatePerNight,
                Capacity = hotel.Capacity,
                Reviews = _dbContext.Reviews.Where(x => x.HotelId == id)
                    .Select(x => new ReviewDetails
                    {
                        Id = x.Id,
                        ReviewerName = x.ReviewerName,
                        ReviewBody = x.ReviewBody,
                        Stars = x.Stars
                    }).ToList(),
                Facilities = _dbContext.Facilities.Where(x => x.Hotels.Any(x => x.Id.Equals(id)))
                    .Select(x => new FacilityApiModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList()
            };
            hotelDetails.RatingStats = new RatingStats
            {
                ReviewsCount = hotelDetails.Reviews.Count(),
                Rating = hotelDetails.Reviews.Count > 0 ? hotelDetails.Reviews.Average(x => x.Stars) : 0
            };
            return hotelDetails;
        }

        public void UpdateHotel(Hotel hotel)
        {
            _dbContext.Entry(hotel).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool IsHotelAvailable(int hotelId, DateTime checkInDate, DateTime checkOutDate)
        {
            return _dbContext.Bookings.Where(x => x.HotelId == hotelId
                                    && (x.StartDate > checkInDate && x.EndDate < checkOutDate)
                                    || (x.StartDate < checkInDate && x.EndDate < checkOutDate)
                                    || (x.StartDate > checkInDate && x.StartDate < checkOutDate && x.EndDate > checkOutDate)
                                    || (x.StartDate < checkInDate && x.EndDate > checkOutDate)).Count() < 1;
        }

        public List<HotelDetailsApiModel> SearchHotels(HotelSearchApiModel query)
        {
            ICollection<Hotel> hotels;
            if(query.FilterTypeId == null)
            {
                hotels = _dbContext.Hotels.Where(x => x.SearchVector.Matches(query.SearchQuery)).ToList();
            }
            else
            {
                var filterName = _dbContext.FilterTypes.Where(x => x.Id == query.FilterTypeId).Select(x => new { x.Name });
                if (string.IsNullOrEmpty(filterName.ToString()))
                    throw new InvalidDataException(Constants.INVALID_FILTER_ID_MESSAGE);

                System.Reflection.PropertyInfo prop = typeof(FilterType).GetProperty(filterName.ToString());
                hotels = _dbContext.Hotels.Where(x => x.SearchVector.Matches(query.SearchQuery)
                                                                    && prop.GetValue(x) == query.FilterValue).ToList();
            }
            if(hotels == null || hotels.Count < 1)
                throw new KeyNotFoundException();
            return GetHotelDetailsFromHotels(hotels);
        }

        private List<HotelDetailsApiModel> GetHotelDetailsFromHotels(ICollection<Hotel> hotels)
        {
            List<HotelDetailsApiModel> hotelDetails = new List<HotelDetailsApiModel>();
            HotelDetailsApiModel hotelDetailsApiModel;
            foreach(Hotel hotel in hotels)
            {
                hotelDetailsApiModel = new HotelDetailsApiModel
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    Description = hotel.Description,
                    RatePerNight = hotel.RatePerNight,
                    Capacity = hotel.Capacity,
                    Reviews = _dbContext.Reviews.Where(x => x.HotelId == hotel.Id)
                   .Select(x => new ReviewDetails
                   {
                       Id = x.Id,
                       ReviewerName = x.ReviewerName,
                       ReviewBody = x.ReviewBody,
                       Stars = x.Stars
                   }).ToList(),
                    Facilities = _dbContext.Facilities.Where(x => x.Hotels.Any(x => x.Id.Equals(hotel.Id)))
                   .Select(x => new FacilityApiModel
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Description = x.Description
                   }).ToList()
                };
                hotelDetailsApiModel.RatingStats = new RatingStats
                {
                    ReviewsCount = hotelDetailsApiModel.Reviews.Count(),
                    Rating = hotelDetailsApiModel.Reviews.Count > 0 ? hotelDetailsApiModel.Reviews.Average(x => x.Stars) : 0
                };
                hotelDetails.Add(hotelDetailsApiModel);
            }
            return hotelDetails;
        }
    }
}

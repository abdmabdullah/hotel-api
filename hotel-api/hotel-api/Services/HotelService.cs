using hotel_api.ApiModels;
using hotel_api.Config;
using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;

namespace hotel_api.Services
{
    public class HotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public ResponseModel GetHotels()
        {
            IEnumerable<Hotel> hotels;
            try
            {
                hotels = _hotelRepository.GetAllHotels();
                return new ResponseModel(hotels, Constants.SUCCESS_MESSAGE, Constants.SUCCESS_CODE);

            }
            catch(KeyNotFoundException)
            {
                return new ResponseModel(null, Constants.NOT_FOUND_MESSAGE, Constants.NOT_FOUND_CODE);
            }
        }

        public ResponseModel SearchHotels(HotelSearchApiModel query)
        {
            try
            {
                List<HotelDetailsApiModel> hotels = _hotelRepository.SearchHotels(query);
                return new ResponseModel(hotels, Constants.SUCCESS_MESSAGE, Constants.SUCCESS_CODE);
            }
            catch(KeyNotFoundException)
            {
                return new ResponseModel(null, Constants.NOT_FOUND_MESSAGE, Constants.NOT_FOUND_CODE);
            }
            catch(InvalidDataException)
            {
                return new ResponseModel(null, Constants.INVALID_FILTER_ID_MESSAGE, Constants.INVALID_FILTER_ID_CODE);
            }
        }

        public ResponseModel GetHotel(int id)
        {
            try
            {
                HotelDetailsApiModel hotel = _hotelRepository.GetHotelById(id);
                return new ResponseModel(hotel, Constants.SUCCESS_MESSAGE, Constants.SUCCESS_CODE);
            }
            catch (KeyNotFoundException)
            {
                return new ResponseModel(null, Constants.NOT_FOUND_MESSAGE, Constants.NOT_FOUND_CODE);
            }
        }

        public ResponseModel AddHotel(HotelApiModel hotel)
        {
            try
            {
                int newHotelId = _hotelRepository.AddHotel(hotel);
                return new ResponseModel(newHotelId, Constants.CREATED_MESSAGE, Constants.CREATED_CODE);
            }
            catch(Exception ex)
            {
                return new ResponseModel(null, Constants.FAILURE_MESSAGE, Constants.FAILURE_CODE);
            }
        }

        public ResponseModel UpdateHotel(Hotel hotel)
        {
            try
            {
                _hotelRepository.UpdateHotel(hotel);
                return new ResponseModel(null, Constants.SUCCESS_MESSAGE, Constants.SUCCESS_CODE);
            }
            catch(KeyNotFoundException)
            {
                return new ResponseModel(null, Constants.NOT_FOUND_MESSAGE, Constants.NOT_FOUND_CODE);
            }
        }

        public ResponseModel DeleteHotel(Hotel hotel)
        {
            try
            {
                _hotelRepository.DeleteHotel(hotel);
                return new ResponseModel(null, Constants.SUCCESS_MESSAGE, Constants.SUCCESS_CODE);
            }
            catch(KeyNotFoundException)
            {
                return new ResponseModel(null, Constants.NOT_FOUND_MESSAGE, Constants.NOT_FOUND_CODE);
            }
        }
    }
}

using hotel_api.ApiModels;
using hotel_api.Config;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;

namespace hotel_api.Services
{
    public class BookingService
    {
        private IBookingRepository _bookingRepository;
        private IHotelRepository _hotelRepository;
        private IUserRepository _userRepository;
        public BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
        }

        public ResponseModel AddBooking(BookingApiModel booking)
        {
            ValidationModel? validationErrors = ValidateNewBooking(booking);
            if (validationErrors != null)
                return new ResponseModel(null, validationErrors.Message, validationErrors.StatusCode);
            int bookingId = _bookingRepository.AddBooking(booking);
            return new ResponseModel(bookingId, Constants.CREATED_MESSAGE, Constants.CREATED_CODE);
        }

        private ValidationModel? ValidateNewBooking(BookingApiModel booking)
        {
            try
            {
                _hotelRepository.GetHotelById(booking.HotelId);
            }
            catch(KeyNotFoundException)
            {
                return new ValidationModel
                {
                    StatusCode = Constants.INVALID_HOTEL_ID_CODE,
                    Message = Constants.INVALID_HOTEL_ID_MESSAGE
                };
            }
            try
            {
                _userRepository.GetUserById(booking.UserId);
            }
            catch (KeyNotFoundException)
            {
                return new ValidationModel
                {
                    StatusCode = Constants.INVALID_USER_CODE,
                    Message = Constants.INVALID_USER_MESSAGE
                };
            }
            if (!_hotelRepository.IsHotelAvailable(booking.HotelId, booking.StartDate, booking.EndDate))
            {
                return new ValidationModel
                {
                    StatusCode = Constants.HOTEL_NOT_AVAILABLE_CODE,
                    Message = Constants.HOTEL_NOT_AVAILABLE_MESSAGE
                };
            }
            return null;
        }
    }
}

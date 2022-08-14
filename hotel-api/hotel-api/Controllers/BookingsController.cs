using hotel_api.ApiModels;
using hotel_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private BookingService _bookingService;
        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public ResponseModel AddBooking(BookingApiModel booking)
        {
            return _bookingService.AddBooking(booking);
        }
    }
}

using hotel_api.ApiModels;
using hotel_api.Models;
using hotel_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private HotelService _hotelService;
        public HotelsController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public ResponseModel GetHotels()
        {
            return _hotelService.GetHotels();
        }

        [HttpPost]
        public ResponseModel SearchHotels([FromBody]HotelSearchApiModel query)
        {
            return _hotelService.SearchHotels(query);
        }
        [HttpGet]
        [Route("{id}")]
        public ResponseModel GetHotel(int id)
        {
            return _hotelService.GetHotel(id);
        }

        [HttpPost]
        public ResponseModel AddHotel(HotelApiModel hotel)
        {
            return _hotelService.AddHotel(hotel);
        }

        [HttpPost]
        public ResponseModel UpdateHotel(Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }

        [HttpPost]
        public ResponseModel DeleteHotel(Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
    }
}

using hotel_api.Models;

namespace hotel_api.ApiModels
{
    public class HotelSearchApiModel
    {
        public string SearchQuery { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? FilterTypeId { get; set; }
        public string? FilterValue { get; set; }
    }
}

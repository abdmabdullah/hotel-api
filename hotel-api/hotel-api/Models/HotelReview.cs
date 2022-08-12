namespace hotel_api.Models
{
    public class HotelReview
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int ReviewId { get; set; }
        public Hotel Review { get; set; }
    }
}

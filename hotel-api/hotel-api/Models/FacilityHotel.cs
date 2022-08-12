namespace hotel_api.Models
{
    public class FacilityHotel
    {
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}

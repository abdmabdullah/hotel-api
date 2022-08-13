namespace hotel_api.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}

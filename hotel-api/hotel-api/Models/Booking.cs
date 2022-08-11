namespace hotel_api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int UserId { get; set; }
    }
}

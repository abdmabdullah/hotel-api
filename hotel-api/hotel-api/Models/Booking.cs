using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

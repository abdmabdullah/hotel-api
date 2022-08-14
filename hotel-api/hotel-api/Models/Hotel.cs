using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel_api.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal RatePerNight { get; set; }
        [Required]
        public int Capacity { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Facility>? Facilities { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}

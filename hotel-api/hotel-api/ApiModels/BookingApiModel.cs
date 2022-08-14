using System.ComponentModel.DataAnnotations;

namespace hotel_api.ApiModels
{
    public class BookingApiModel
    {
        public int Id { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

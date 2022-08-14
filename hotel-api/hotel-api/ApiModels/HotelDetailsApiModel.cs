using hotel_api.Models;
using System.ComponentModel.DataAnnotations;

namespace hotel_api.ApiModels
{
    public class HotelDetailsApiModel
    {
        [Required]
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
        public List<ReviewDetails>? Reviews { get; set; }
        public List<FacilityApiModel>? Facilities { get; set; }
        public RatingStats RatingStats { get; set; }
    }
}

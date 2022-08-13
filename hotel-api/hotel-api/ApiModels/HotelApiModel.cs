using System.ComponentModel.DataAnnotations;

namespace hotel_api.ApiModels
{
    public class HotelApiModel
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
        [Required]
        public List<int> FacilityIds { get; set; }
    }
}

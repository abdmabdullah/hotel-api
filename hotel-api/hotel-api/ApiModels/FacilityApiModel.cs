using System.ComponentModel.DataAnnotations;

namespace hotel_api.ApiModels
{
    public class FacilityApiModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

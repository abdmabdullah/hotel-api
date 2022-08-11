namespace hotel_api.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}

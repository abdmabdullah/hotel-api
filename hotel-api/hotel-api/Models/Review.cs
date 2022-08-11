namespace hotel_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewBody { get; set; }
        public int Stars { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}

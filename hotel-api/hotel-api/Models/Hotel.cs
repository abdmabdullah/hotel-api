﻿namespace hotel_api.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal RatePerNight { get; set; }
        public int Capacity { get; set; }
        public List<Facility> facilities;
        public List<Review> reviews;
    }
}

using hotel_api.Models;

namespace hotel_api.Repository.RepositoryInterfaces
{
    public interface IReviewRepository : IDisposable
    {
        IEnumerable<Review> GetAllReviews();
        Review GetReviewById(int id);
        IEnumerable<Review> GetReviewsByHotelId(int hotelId);
        void AddReview(Review review, int hotelId);
        void DeleteReview(Review review);
        double GetStarRatingForHotel(int hotelId);
    }
}

using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;

namespace hotel_api.Repository.RepositoryConcrete
{
    public class ReviewRepository : IReviewRepository, IDisposable
    {
        private DataContext _dbContext;
        public ReviewRepository(DataContext context)
        {
            _dbContext = context;
        }

        public void AddReview(Review review, int hotelId)
        {
            _dbContext.Reviews.Add(review);
        }

        public void DeleteReview(Review review)
        {
            Review reviewToRemove = _dbContext.Reviews.Find(review);
            if (reviewToRemove == null)
                throw new KeyNotFoundException("Review not found");
            _dbContext.Reviews.Remove(reviewToRemove);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _dbContext.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            Review review = _dbContext.Reviews.Find(id);
            if (review == null)
                throw new KeyNotFoundException("Review not found");
            return review;
        }

        public IEnumerable<Review> GetReviewsByHotelId(int hotelId)
        {
            IEnumerable<Review> reviews = _dbContext.Reviews.Where(x => x.HotelId == hotelId);
            if (reviews == null)
                throw new KeyNotFoundException("No reviews found");
            return reviews;
        }

        public double GetStarRatingForHotel(int hotelId)
        {
            return _dbContext.Reviews.Where(x => x.HotelId == hotelId).Select(x => x.Stars).Average();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

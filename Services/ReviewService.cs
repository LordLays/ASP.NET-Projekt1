using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class ReviewService
    {
        private readonly ITravelAgencyRepository<Review> ReviewRepository;
        public List<Review> GetByRating(int rating)
        {
            return ReviewRepository.GetAll().Where(r => r.Rating == rating).ToList();
        }
        public void SortByRatingASC(List<Review> reviews)
        {
            reviews.Sort((r1, r2) => r1.Rating.CompareTo(r2.Rating));
        }
        public void SortByRatingDESC(List<Review> reviews)
        {
            reviews.Sort((r1, r2) => r2.Rating.CompareTo(r1.Rating));
        }
        public void AddReview(Review review)
        {
            ReviewRepository.AddItem(review);
        }
        public void UpdateReview(Review review)
        {
            ReviewRepository.UpdateItem(review);
        }
        public void DeleteReview(int id)
        {
            ReviewRepository.DeleteItem(id);
        }
    }
}

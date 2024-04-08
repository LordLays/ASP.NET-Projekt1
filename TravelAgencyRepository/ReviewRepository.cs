using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ReviewRepository : ITravelAgencyRepository<Review>
    {
        private readonly TravelAgencyContext _context;
        public ReviewRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(Review item)
        {
            _context.Reviews.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var review = GetById(id);
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }
        public Review GetById(int id)
        {
            return _context.Reviews.Find(id);
        }
        public IQueryable<Review> GetAll()
        {
            return _context.Reviews;
        }
        public void UpdateItem(Review item)
        {
            _context.Reviews.Update(item);
            _context.SaveChanges();
        }
    }
}

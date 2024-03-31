using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class HotelRepository : ITravelAgencyRepository<Hotel>
    {
        private readonly TravelAgencyContext _context;
        public HotelRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(Hotel item)
        {
            _context.Hotels.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var hotel = GetById(id);
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }
        public Hotel GetById(int id)
        {
            return _context.Hotels.Find(id);
        }
        public IQueryable<Hotel> GetQueryable()
        {
            return _context.Hotels;
        }
        public void UpdateItem(Hotel item)
        {
            _context.Hotels.Update(item);
            _context.SaveChanges();
        }
    }
}

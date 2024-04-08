using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OfertRepository : ITravelAgencyRepository<Ofert>
    {
        private readonly TravelAgencyContext _context;
        public OfertRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(Ofert item)
        {
            _context.Oferts.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var ofert = GetById(id);
            _context.Oferts.Remove(ofert);
            _context.SaveChanges();
        }
        public Ofert GetById(int id)
        {
            return _context.Oferts.Find(id);
        }
        public IQueryable<Ofert> GetAll()
        {
            return _context.Oferts;
        }
        public void UpdateItem(Ofert item)
        {
            _context.Oferts.Update(item);
            _context.SaveChanges();
        }
    }
}

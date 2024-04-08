using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ReservationRepository : ITravelAgencyRepository<Reservation>
    {
        private readonly TravelAgencyContext _context;
        public ReservationRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(Reservation item)
        {
            _context.Reservations.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var reservation = GetById(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
        public Reservation GetById(int id)
        {
            return _context.Reservations.Find(id);
        }
        public IQueryable<Reservation> GetAll()
        {
            return _context.Reservations;
        }
        public void UpdateItem(Reservation item)
        {
            _context.Reservations.Update(item);
            _context.SaveChanges();
        }
    }
}

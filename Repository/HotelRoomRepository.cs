using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class HotelRoomRepository : ITravelAgencyRepository<HotelRoom>
    {
        private readonly TravelAgencyContext _context;
        public HotelRoomRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void AddItem(HotelRoom item)
        {
            _context.HotelRooms.Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var hotelRoom = GetById(id);
            _context.HotelRooms.Remove(hotelRoom);
            _context.SaveChanges();
        }
        public HotelRoom GetById(int id)
        {
            return _context.HotelRooms.Find(id);
        }
        public IQueryable<HotelRoom> GetQueryable()
        {
            return _context.HotelRooms;
        }
        public void UpdateItem(HotelRoom item)
        {
            _context.HotelRooms.Update(item);
            _context.SaveChanges();
        }
    }
}

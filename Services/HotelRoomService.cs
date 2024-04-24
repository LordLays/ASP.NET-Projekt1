using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class HotelRoomService
    {
        private readonly ITravelAgencyRepository<HotelRoom> HotelRoomRepository;
        public List<HotelRoom> GetByRoomType(TypeRoom roomType)
        {
            return HotelRoomRepository.GetAll().Where(r => r.Type == roomType).ToList();
        }
        public List<HotelRoom> GetByCapacity(int capacity)
        {
            return HotelRoomRepository.GetAll().Where(r => r.Capacity == capacity).ToList();
        }
        public List<HotelRoom> GetByAvailability(bool available)
        {
            return HotelRoomRepository.GetAll().Where(r => r.Available == available).ToList();
        }
        public void AddHotelRoom(HotelRoom hotelRoom)
        {
            HotelRoomRepository.AddItem(hotelRoom);
        }
        public void UpdateHotelRoom(HotelRoom hotelRoom)
        {
            HotelRoomRepository.UpdateItem(hotelRoom);
        }
        public void DeleteHotelRoom(int id)
        {
            HotelRoomRepository.DeleteItem(id);
        }
    }
}

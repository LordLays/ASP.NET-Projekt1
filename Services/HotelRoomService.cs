using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class HotelRoomService
    {
        private readonly ITravelAgencyRepository<HotelRoom> HotelRoomRepository;
        public List<HotelRoom> GetByBetweenPrice(int lowerPrice, int higherPrice)
        {
            return HotelRoomRepository.GetAll().Where(r => r.Price >= lowerPrice && r.Price <= higherPrice).ToList();
        }
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
        public void SortPriceASC(List<HotelRoom> hotelRooms)
        {
            hotelRooms.Sort((r1, r2) => r1.Price.CompareTo(r2.Price));
        }
        public void SortPriceDESC(List<HotelRoom> hotelRooms)
        {
            hotelRooms.Sort((r1, r2) => r2.Price.CompareTo(r1.Price));
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

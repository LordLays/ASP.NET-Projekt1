using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class HotelService
    {
        private readonly ITravelAgencyRepository<Hotel> HotelRepository;
        public List<Hotel> GetByName(string name)
        {
            return HotelRepository.GetAll().Where(h => h.Name == name).ToList();
        }
        public List<Hotel> GetByLocation(string city, string country)
        {
            if (city != null && country != null)
            {
                return HotelRepository.GetAll().Where(h => h.City == city && h.Country == country).ToList();
            }
            else if (city != null)
            {
                return HotelRepository.GetAll().Where(h => h.City == city).ToList();
            }
            else if (country != null)
            {
                return HotelRepository.GetAll().Where(h => h.Country == country).ToList();
            }
            else return HotelRepository.GetAll().ToList();
        }
        public List<Hotel> GetByStarRating(int starRating)
        {
            return HotelRepository.GetAll().Where(h => h.StarRating == starRating).ToList();
        }
        public List<Hotel> GetByAverageCustomersRating(double averageCustomersRating)
        {
            return HotelRepository.GetAll().Where(h => h.AverageCustomersRating == averageCustomersRating).ToList();
        }
        public void SortByStarRatingASC(List<Hotel> hotels)
        {
            hotels.Sort((h1, h2) => h1.StarRating.CompareTo(h2.StarRating));
        }
        public void SortByStarRatingDESC(List<Hotel> hotels)
        {
            hotels.Sort((h1, h2) => h2.StarRating.CompareTo(h1.StarRating));
        }
        public void SortByAverageCustomersRatingASC(List<Hotel> hotels)
        {
            hotels.Sort((h1, h2) => h1.AverageCustomersRating.CompareTo(h2.AverageCustomersRating));
        }
        public void SortByAverageCustomersRatingDESC(List<Hotel> hotels)
        {
            hotels.Sort((h1, h2) => h2.AverageCustomersRating.CompareTo(h1.AverageCustomersRating));
        }
        public void AddHotel(Hotel hotel)
        {
            HotelRepository.AddItem(hotel);
        }
        public void UpdateHotel(Hotel hotel)
        {
            HotelRepository.UpdateItem(hotel);
        }
        public void DeleteHotel(int id)
        {
            HotelRepository.DeleteItem(id);
        }
    }
}

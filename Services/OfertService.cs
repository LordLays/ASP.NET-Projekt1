using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class OfertService
    {
        private readonly ITravelAgencyRepository<Ofert> OfertRepository;
        public List<Ofert> SearchOfert(string? hotelName, DateOnly? startDate, DateOnly? endDate, string? takeOffPlace, int? availableSeats)
        {
            if (hotelName != null && startDate != null && endDate != null && takeOffPlace != null && availableSeats != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.Hotel.Name == hotelName && o.StartDate == startDate && o.EndDate == endDate && o.TakeOffPlace == takeOffPlace && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (hotelName != null && startDate != null && endDate != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.Hotel.Name == hotelName && o.StartDate == startDate && o.EndDate == endDate && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (hotelName != null && startDate != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.Hotel.Name == hotelName && o.StartDate == startDate && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (hotelName != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.Hotel.Name == hotelName && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (startDate != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.StartDate == startDate && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (endDate != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.EndDate == endDate && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else if (takeOffPlace != null)
            {
                return OfertRepository.GetAll()
                    .Where(o => o.TakeOffPlace == takeOffPlace && o.AvailableSeats >= availableSeats)
                    .ToList();
            }
            else
            {
                return OfertRepository.GetAll().Where(o => o.AvailableSeats >= availableSeats).ToList();
            }
        }
        public void SortByPriceASC(List<Ofert> oferts)
        {
            oferts.Sort((o1, o2) => o1.Price.CompareTo(o2.Price));
        }
        public void SortByPriceDESC(List<Ofert> oferts)
        {
            oferts.Sort((o1, o2) => o2.Price.CompareTo(o1.Price));
        }
        public void SortByAvailableSeatsASC(List<Ofert> oferts)
        {
            oferts.Sort((o1, o2) => o1.AvailableSeats.CompareTo(o2.AvailableSeats));
        }
        public void SortByAvailableSeatsDESC(List<Ofert> oferts)
        {
            oferts.Sort((o1, o2) => o2.AvailableSeats.CompareTo(o1.AvailableSeats));
        }
        public void AddOfert(Ofert ofert)
        {
            OfertRepository.AddItem(ofert);
        }
        public void UpdateOfert(Ofert ofert)
        {
            OfertRepository.UpdateItem(ofert);
        }
        public void DeleteOfert(int id)
        {
            OfertRepository.DeleteItem(id);
        }
    }
}

using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class ReservationService
    {
        private readonly ITravelAgencyRepository<Reservation> ReservationRepository;
        public List<Reservation> GetByMeal(Meal meal)
        {
            return ReservationRepository.GetAll().Where(r => r.Meal == meal).ToList();
        }
        public void AddReservation(Reservation reservation)
        {
            ReservationRepository.AddItem(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {
            ReservationRepository.UpdateItem(reservation);
        }
        public void DeleteReservation(int id)
        {
            ReservationRepository.DeleteItem(id);
        }
    }
}

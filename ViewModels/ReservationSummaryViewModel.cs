using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class ReservationSummaryViewModel
    {
        public uint ReservationID { get; set; }
        public uint OfertID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HotelAddress { get; set; }
        public Meal Meal { get; set; }
        public string TakeOffPlace { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<HotelRoom> BookedRooms { get; set; }

    }
}

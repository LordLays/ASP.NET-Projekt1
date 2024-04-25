using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HotelOffertViewModel
    {
        public uint IDOfert { get; set; }       
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int StarRating { get; set; }
        public string TakeOffPlace { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public Meal Meal { get; set; }
        public TripType TripType { get; set; }
        public List<string>? ImageUrl { get; set; }
    }
}

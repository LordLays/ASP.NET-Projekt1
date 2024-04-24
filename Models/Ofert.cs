namespace WebApplication1.Models
{
    public enum Meal
    {
        Breakfast,
        HalfBoard,
        FullBoard,
        AllInclusive
    }
    public enum TripType
    {
        Guided,
        Adventure,
        Cultural,
        Relaxation,
        Themed,
        Family,
        Incentive,
        Extreme,
        Luxury,
        Celebrity
    }
    public class Ofert
    {
        public uint IDOfert { get; set; }
        public uint? HotelID { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string TakeOffPlace { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public Meal Meal { get; set; }
        public TripType TripType { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}

namespace WebApplication1.Models
{
    //Generate enum for Meal
    public enum Meal
    {
        Breakfast,
        HalfBoard,
        FullBoard,
        AllInclusive
    }
    public class Reservation
    {
        public uint ID { get; set; }
        public Customer Customer { get; set; }
        public Ofert Ofert { get; set; }
        public List<HotelRoom> BookedRoom { get; set; }
        public int Travelers { get; set; }
        public Meal Meal { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

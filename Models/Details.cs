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
    public class Details
    {
        public uint ID { get; set; }
        public Custormers Customer { get; set; }
        public Oferts Ofert { get; set; }
        public List<HotelRoom> BookedRoom { get; set; }
        public int Travelers { get; set; }
        public Enum Meal { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

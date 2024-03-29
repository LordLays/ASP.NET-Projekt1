namespace WebApplication1.Models
{
    public class Oferts
    {
        public uint ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Hotel Hotel { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string TakeOffPlace { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}

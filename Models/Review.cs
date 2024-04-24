namespace WebApplication1.Models
{
    public class Review
    {
        public uint IDReview { get; set; }
        public uint CustomerID { get; set; }
        public uint HotelID { get; set; }
        public int Rating { get; set; }
        public string? Reviews { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}

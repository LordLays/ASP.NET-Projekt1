namespace WebApplication1.ViewModels
{
    public class ReviewViewModel
    {
        public uint IDReview { get; set; }
        public string Name { get; set; }
        public string HotelName { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
    }
}

namespace WebApplication1.Models
{
    public class Hotel
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int StarRating { get; set; }
        public List<HotelRoom> Rooms { get; set; }
        public string? Description { get; set; }
        public LinkedList<Reviews> Reviews { get; set; }
        public double AverageCustomersRating { get; set; }
        public List<string>? ImageUrl { get; set; }

        public double AverageRating()
        {
            double sum = 0;
            foreach (var review in Reviews)
            {
                sum += review.Rating;
            }
            return sum / Reviews.Count;
        }
    }
}

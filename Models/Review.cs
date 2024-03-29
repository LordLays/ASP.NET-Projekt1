namespace WebApplication1.Models
{
    public class Review
    {
        public uint ID { get; set; }
        public int Rating { get; set; }
        public string? Reviews { get; set; }
        public Customer Customer { get; set; }
    }
}

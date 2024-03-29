namespace WebApplication1.Models
{
    public class Reviews
    {
        public uint ID { get; set; }
        public int Rating { get; set; }
        public string? Review { get; set; }
        public Custormers Customer { get; set; }
    }
}

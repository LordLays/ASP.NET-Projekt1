namespace WebApplication1.Models
{
    public enum TypeRoom
    {
        Single,
        Double,
        Twin,
        Family,
        Suite,
        Studio
        
    }
    public class HotelRoom
    {
        public uint ID { get; set; }
        public TypeRoom Type { get; set; }
        public string? Description { get; set; }
        public uint Capacity { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}

using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HotelRoomViewModel
    {
        public uint IDHotelRoom { get; set; }
        public string HotelName { get; set; }
        public string Number { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public string? Description { get; set; }
        public uint Capacity { get; set; }
        public bool Available { get; set; }
    }
}

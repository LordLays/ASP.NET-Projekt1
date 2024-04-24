namespace WebApplication1.Models
{
    public class Reservation
    {
        public uint IDReservation { get; set; }
        public uint CustomerID { get; set; }
        public uint OfertID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Ofert Ofert { get; set; }
        public virtual List<HotelRoom> BookedRooms { get; set; }
    }
}

﻿namespace WebApplication1.Models
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
        public uint IDHotelRoom { get; set; }
        public uint HotelID { get; set; }
        public uint Number { get; set; }
        public TypeRoom Type { get; set; }
        public string? Description { get; set; }
        public uint Capacity { get; set; }
        public bool Available { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}

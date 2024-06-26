﻿namespace WebApplication1.Models
{
    public class Hotel
    {
        public uint IDHotel { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int StarRating { get; set; }
        public string? Description { get; set; }
        public double AverageCustomersRating { get; set; }
        public List<string>? ImageUrl { get; set; }

        public virtual List<HotelRoom> RoomList { get; set; }
    }
}

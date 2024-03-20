using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class TripGuide
    {
        public int GuideId { get; set; }
        public int TripId { get; set; }
        public string GuideName { get; set; }
        public string GuidePhoneNumber { get; set; }
        public string GuideEmail { get; set; }

        [ForeignKey("TripId")]
        public virtual List<Trip> Trips { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class TripReview
    {
        public int ReviewId { get; set; }
        public int TripParticipantId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public virtual List<TripParticipant> TripParticipants { get; set; }

    }
}

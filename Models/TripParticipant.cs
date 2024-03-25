using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class TripParticipant
    {
        public int ParticipantId { get; set; }
        public int TripId { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantEmail { get; set; }
        public string ParticipantPhoneNumber { get; set; }

        public virtual List<TripReview> TripReviews { get; set; }

    }
}

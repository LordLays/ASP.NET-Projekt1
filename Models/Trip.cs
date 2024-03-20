using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace WebApplication1.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int GuideId { get; set; }
        public int ParticipantId { get; set; }

        [ForeignKey("GuideId")]
        public virtual List<TripGuide> TripGuides { get; set; }
        [ForeignKey("ParticipantId")]
        public virtual List<TripParticipant> TripParticipants { get; set; }
        [ForeignKey("ReviewId")]
        public virtual List<TripReview> TripReviews { get; set; }

        public Trip() { }
        public Trip(int id, string name, string place, DateOnly date, TimeSpan duration)
        {
            TripId = id;
            Name = name;
            Place = place;
            Date = date;
            Duration = duration;
        }
        public static void SaveTrips(List<Trip> trips)
        {
            string tripsJson = JsonSerializer.Serialize(trips);
            File.WriteAllText("trips.json", tripsJson);
        }
        public static List<Trip> LoadTrips()
        {
            string tripsJson = File.ReadAllText("trips.json");
            List<Trip> trips = JsonSerializer.Deserialize<List<Trip>>(tripsJson);
            return trips;
        }
        public static List<Trip> SampleTripList()
        {
            List<Trip> trips = new List<Trip>
            {
                new Trip(0, "Trip to Paris", "Paris", new DateOnly(2022, 7, 14), new TimeSpan(7, 0, 0, 0)),
                new Trip(1, "Trip to London", "London", new DateOnly(2022, 8, 14), new TimeSpan(5, 0, 0, 0)),
                new Trip(2, "Trip to New York", "New York", new DateOnly(2022, 9, 14), new TimeSpan(14, 0, 0, 0))
            };
            return trips;
        }
        public static List<Trip> GetAllTrips()
        {
            if (File.Exists("trips.json"))
            {
                return LoadTrips();
            }
            else
            {
                return SampleTripList();
            }
        }
        public static Trip GetTripById(int id)
        {
            return GetAllTrips().FirstOrDefault(t => t.TripId == id);
        }
        public static void AddTrip(Trip trip)
        {
            List<Trip> trips = GetAllTrips();
            trips.Add(trip);
        }
        public static void DeleteTrip(int id)
        {
            List<Trip> trips = GetAllTrips();
            Trip trip = trips.FirstOrDefault(t => t.TripId == id);
            trips.Remove(trip);
        }
    }
}

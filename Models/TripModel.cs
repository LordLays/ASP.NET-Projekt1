using System.Text.Json;

namespace WebApplication1.Models
{
    public class TripModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Place { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Duration { get; set; }

        public TripModel(int id, string name, string? description, string place, DateOnly date, TimeSpan duration)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
            Date = date;
            Duration = duration;
        }
        public static void SaveTrips(List<TripModel> trips)
        {
            string tripsJson = JsonSerializer.Serialize(trips);
            File.WriteAllText("trips.json", tripsJson);
        }
        public static List<TripModel> LoadTrips()
        {
            string tripsJson = File.ReadAllText("trips.json");
            List<TripModel> trips = JsonSerializer.Deserialize<List<TripModel>>(tripsJson);
            return trips;
        }
        public static List<TripModel> SampleTripList()
        {
            List<TripModel> trips = new List<TripModel>
            {
                new TripModel(0, "Trip to Paris", "Sightseeing", "Paris", new DateOnly(2022, 7, 14), new TimeSpan(7, 0, 0, 0)),
                new TripModel(1, "Trip to London", "Sightseeing", "London", new DateOnly(2022, 8, 14), new TimeSpan(5, 0, 0, 0)),
                new TripModel(2, "Trip to New York", "Sightseeing", "New York", new DateOnly(2022, 9, 14), new TimeSpan(14, 0, 0, 0))
            };
            return trips;
        }
        public static List<TripModel> GetAllTrips()
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
        public static TripModel GetTripById(int id)
        {
            return GetAllTrips().FirstOrDefault(t => t.Id == id);
        }
        public static void AddTrip(TripModel trip)
        {
            List<TripModel> trips = GetAllTrips();
            trips.Add(trip);
        }
        public static void UpdateTrip(TripModel trip)
        {
            List<TripModel> trips = GetAllTrips();
            TripModel oldTrip = trips.FirstOrDefault(t => t.Id == trip.Id);
            trips.Remove(oldTrip);
            trips.Add(trip);
        }
        public static void DeleteTrip(int id)
        {
            List<TripModel> trips = GetAllTrips();
            TripModel trip = trips.FirstOrDefault(t => t.Id == id);
            trips.Remove(trip);
        }
    }
}

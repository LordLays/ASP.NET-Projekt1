using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        private List<Trip> _tripsList = Trip.GetAllTrips();
        // GET: TripController
        public ActionResult Index()
        {
            return View(_tripsList);
        }

        // GET: TripController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Trip trip = new Trip(_tripsList.Count, collection["Name"], collection["Place"], 
                    DateOnly.Parse(collection["Date"]), TimeSpan.Parse(collection["Duration"]));
                _tripsList.Add(trip);
                Trip.SaveTrips(_tripsList);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripController/Edit/5
        public ActionResult Edit(int itemId)
        {
            var trip = Trip.GetTripById(itemId);
            if (trip == null)
            {
                return View("NotFound");
            }

            return View(trip);
        }

        // POST: TripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int itemId, IFormCollection collection)
        {
            try
            {
                Trip newTrip = new Trip();
                newTrip.Name = collection["Name"];
                newTrip.Place = collection["Place"];
                newTrip.Date = DateOnly.Parse(collection["Date"]);
                newTrip.Duration = TimeSpan.Parse(collection["Duration"]);
                _tripsList[itemId].Name = newTrip.Name;
                _tripsList[itemId].Place = newTrip.Place;
                _tripsList[itemId].Date = newTrip.Date;
                _tripsList[itemId].Duration = newTrip.Duration;
                Trip.SaveTrips(_tripsList);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripController/Delete/5
        [HttpGet]
        public ActionResult Delete(int itemId)
        {
            return View(Trip.GetTripById(itemId));
        }

        // POST: TripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int itemId, IFormCollection collection)
        {
            try
            {
                _tripsList.Remove(_tripsList[itemId]);
                Trip.SaveTrips(_tripsList);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

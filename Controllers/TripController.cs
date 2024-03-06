using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        private readonly List<TripModel> _tripsList = TripModel.GetAllTrips();
        // GET: TripController
        public ActionResult Index()
        {
            return View(_tripsList);
        }

        // GET: TripController/Details/5
        public ActionResult Details(int id)
        {
            return View(TripModel.GetTripById(id));
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
                TripModel trip = new TripModel(_tripsList.Count + 1, collection["Name"], collection["Description"], collection["Place"], DateOnly.Parse(collection["Date"]), TimeSpan.Parse(collection["Duration"]));
                _tripsList.Add(trip);
                TripModel.SaveTrips(_tripsList);
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
            var trip = TripModel.GetTripById(itemId);
            if (trip == null)
            {
                return NotFound(); // Możesz zwrócić odpowiedni widok lub kod błędu HTTP, np. NotFound()
            }

            return View(trip);
        }

        // POST: TripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                TripModel trip = TripModel.GetTripById(id);
                trip.Name = collection["Name"];
                trip.Description = collection["Description"];
                trip.Place = collection["Place"];
                trip.Date = DateOnly.Parse(collection["Date"]);
                trip.Duration = TimeSpan.Parse(collection["Duration"]);
                TripModel.UpdateTrip(trip);
                TripModel.SaveTrips(_tripsList);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _tripsList.Remove(TripModel.GetTripById(id));
                TripModel.SaveTrips(_tripsList);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

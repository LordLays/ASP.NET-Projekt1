using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        private List<TripModel> _tripsList = TripModel.GetAllTrips();
        // GET: TripController
        public ActionResult Index()
        {
            return View(_tripsList);
        }

        // GET: TripController/Details/5
        public ActionResult Details(int itemId)
        {
            return View(TripModel.GetTripById(itemId));
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
                TripModel trip = new TripModel(_tripsList.Count, collection["Name"], collection["Description"], collection["Place"], DateOnly.Parse(collection["Date"]), TimeSpan.Parse(collection["Duration"]));
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
                TripModel newTrip = new TripModel();
                newTrip.Name = collection["Name"];
                newTrip.Description = collection["Description"];
                newTrip.Place = collection["Place"];
                newTrip.Date = DateOnly.Parse(collection["Date"]);
                newTrip.Duration = TimeSpan.Parse(collection["Duration"]);
                _tripsList[itemId].Name = newTrip.Name;
                _tripsList[itemId].Description = newTrip.Description;
                _tripsList[itemId].Place = newTrip.Place;
                _tripsList[itemId].Date = newTrip.Date;
                _tripsList[itemId].Duration = newTrip.Duration;
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
        public ActionResult Delete(int itemId)
        {
            return View(TripModel.GetTripById(itemId));
        }

        // POST: TripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int itemId, IFormCollection collection)
        {
            try
            {
                _tripsList.Remove(_tripsList[itemId]);
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

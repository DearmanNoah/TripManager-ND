using M8_Project2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace M8_Project2.Controllers
{
    public class HomeController : Controller
    {
        private TripContext context { get; set; }
        public HomeController(TripContext ctx) => context = ctx;
        public ViewResult Index()
        {
            if (TempData.Keys.Contains("Destination"))
            {
                ViewBag.SubHeader = "Added";
            }
            var trips = context.Trips.OrderBy(m => m.TripId).ToList();
            return View(trips);
        }
        [HttpGet]
        public IActionResult Page(int id)
        {
            if (id == 1)
            {
                TempData.Clear();
                ViewBag.SubHeader = "Page1";
                ViewBag.Action = "Add Destination";
                return View("Page1", new Trip());
            }
            if (id == 2)
            {
                ViewBag.Subheader = "Page2";
                ViewBag.Action = "Add Info to Accommodation";
                return View("Page2", new Trip());
            }
            if (id == 3)
            {
                ViewBag.Subheader = "Page3";
                ViewBag.Action = "Add Things to Do in Destination";
                return View("Page3", new Trip());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Page(int id, Trip trip)
        {
            if (id == 2)
            {
                if (ModelState.IsValid)
                {
                    TempData.Clear();
                    TempData["ID"] = trip.TripId;
                    TempData["Destination"] = trip.Destination;
                    TempData["Accommodation"] = trip.Accommodation;
                    TempData["Start Date"] = trip.StartDate;
                    TempData["End Date"] = trip.EndDate;
                    return RedirectToAction("Page", 2);
                }
                else
                {
                    return RedirectToAction("Page", "Home", 1);
                }
            }
            if (id == 3)
            {
                TempData["Phone Number"] = trip.AccommodationPhone;
                TempData["Email Address"] = trip.AccommodationEmail;
                return RedirectToAction("Page", 3);
            }
            if (id == 4)
            {
                trip.TripId = Convert.ToInt32(TempData["ID"]);
                trip.Destination = TempData.Peek("Destination")?.ToString() ?? string.Empty;
                trip.Accommodation = TempData["Accommodation"]?.ToString() ?? string.Empty;
                trip.StartDate = Convert.ToDateTime(TempData["Start Date"]);
                trip.EndDate = Convert.ToDateTime(TempData["End Date"]);
                trip.AccommodationPhone = TempData["Phone Number"]?.ToString() ?? string.Empty;
                trip.AccommodationEmail = TempData["Email Address"]?.ToString() ?? string.Empty;
                context.Trips.Add(trip);
                context.SaveChanges();
                ViewBag.SubHeader = "Page4";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
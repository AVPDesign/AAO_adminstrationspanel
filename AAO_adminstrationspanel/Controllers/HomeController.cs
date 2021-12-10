using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AAO_adminstrationspanel.Models;

namespace AAO_adminstrationspanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly uclweb_gr3Context _db;

        public HomeController(ILogger<HomeController> logger, uclweb_gr3Context db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: OpretTur
        public IActionResult OpretTur()
        {
            return View();
        }

        // POST: OpretTur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OpretTur(Trip trip)
        {
            if (ModelState.IsValid)
            {
                // Add trip to db
                _db.Trips.Add(trip);
                // Save changes to db
                _db.SaveChanges();
                // Redirect to view
                return RedirectToAction("AlleTure");
            }
            // If data is not valid
            return View(trip);
        }

        public IActionResult AlleTure()
        {
            IEnumerable<Trip> trips = _db.Trips;
            return View(trips);
        }

        public IActionResult TildelteTure()
        {
            IEnumerable<TripUser> tripuser = _db.TripUsers;
            return View(tripuser);
        }

        public IActionResult AfloserOversigt()
        {
            IEnumerable<User> users = _db.Users;
            return View(users);
        }
    }
}

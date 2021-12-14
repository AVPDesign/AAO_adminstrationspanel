using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AAO_adminstrationspanel.Models;
using AAO_adminstrationspanel.ViewModels;

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
            var result =
                (from trip in _db.Trips
                 join tripUser in _db.TripUsers
                 on trip.Id equals tripUser.TripId
                 join user in _db.Users
                 on tripUser.UserId equals user.Id
                 join driver in _db.Drivers
                 on user.Id equals driver.UserId
                 select new TripUserDriverVM
                 {
                     // Trip
                     TripId = trip.Id,
                     StartDate = trip.StartDate,
                     EndDate = trip.EndDate,
                     Priority = trip.Priority,
                     TravelTime = trip.TravelTime,
                     Description = trip.Description,
                     ContactId = trip.ContactId,
                     DepartmentId = trip.DepartmentId,
                     StartCountryId = trip.StartCountryId,
                     EndCountryId = trip.EndCountryId,

                     // User
                     FirstName = user.FirstName,
                     LastName = user.LastName,
                     Phone = user.Phone,
                     RoleId = user.RoleId,
                     LoginId = user.LoginId,
                     AddressId = user.AddressId,

                     // Driver
                     DriverId = driver.Id,
                     ExpirationDate = driver.ExpirationDate,
                     UserId = driver.UserId,
                     DriverLicenseTypeId = driver.DriverLicenseTypeId

                 }).ToList();

            return View(result);
        }

        public IActionResult TildelteTure()
        {
            return View();
        }

        public IActionResult AfloserOversigt()
        {
            IEnumerable<User> users = _db.Users;
            return View(users);
        }

    }
}

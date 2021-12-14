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
            IEnumerable<Trip> trips = _db.Trips;
            return View(trips);
        }

        //public IActionResult TildelteTure()
        //{
        //    IEnumerable<TripUser> tripuser = _db.TripUsers;
        //    return View(tripuser);
        //}

        public IActionResult TildelteTure()
        {
            var result =
            (from trip in _db.Trips
             join Department in _db.Departments
             on trip.Id equals Department.Id

             join Country in _db.Countries
             on trip.StartCountry equals Country.Id

             join user in _db.Users
             on 


             select new AssignedTripsVM
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

                    // Department
                    DepartmentId = department.Id,
                    DepartmentName = department.Name,
                    DepartmentCVR = department.CVR,
                    DepartmentPhone = department.Phone,
                    DepartmentFax = department.fax,
                    DepartmentAddressId = Department.addressId,

                    // Country
                    CountryId = country.id,
                    CountryCode = country.CountryCode,
                    Country1 = country.Country1,

                    // TripUser
                    TripId = TripUser.tripId,
                    UserId = TripUser.userId

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
                    DriverLicenseTypeId = driver.DriverLicenseTypeId,

    }).ToList();

        return View(result);
        }

    public IActionResult AfloserOversigt()
        {
            IEnumerable<User> users = _db.Users;
            return View(users);
        }
    }
}

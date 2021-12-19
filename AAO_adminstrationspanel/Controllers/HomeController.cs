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
            (from department in _db.Departments

             join trip in _db.Trips
             on department.Id equals trip.DepartmentId

             join country in _db.Countries
             on trip.StartCountryId equals country.Id

             join endCountry in _db.Countries
             on trip.EndCountryId equals endCountry.Id

             join tripUser in _db.TripUsers
             on trip.Id equals tripUser.TripId

             join user in _db.Users
             on tripUser.UserId equals user.Id

             join driver in _db.Drivers
             on user.Id equals driver.UserId

             join driverlicensetype in _db.DriverLicenseTypes
             on driver.DriverLicenseTypeId equals driverlicensetype.Id


             select new TripUserDriverVM
             {
                 // Department
                 DepartmentId = department.Id,
                 Name = department.Name,
                 Cvr = department.Cvr,
                 DepartmentPhone = department.Phone,
                 Fax = department.Fax,
                 DepartmentAddressId = department.AddressId,

                 // Trip
                 TripId = trip.Id,
                 StartDate = trip.StartDate,
                 EndDate = trip.EndDate,
                 Priority = trip.Priority,
                 TravelTime = trip.TravelTime,
                 Description = trip.Description,
                 ContactId = trip.ContactId,
                 //DepartmentId = trip.DepartmentId,
                 StartCountryId = trip.StartCountryId,
                 EndCountryId = trip.EndCountryId,

                 // Country
                 Id = country.Id,
                 CountryCode = country.CountryCode,
                 StartCountryCode = country.CountryCode,

                 EndCountryCode = endCountry.CountryCode,

                 // TripUser
                 //TripId = tripUser.TripId,
                 UserId = tripUser.UserId,
                 Assigned = tripUser.Assigned,

                 // User
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                 Phone = user.Phone,
                 RoleId = user.RoleId,
                 LoginId = user.LoginId,
                 AddressId = user.AddressId,
                 Email = user.Email,

                 // Driver
                 DriverId = driver.Id,
                 ExpirationDate = driver.ExpirationDate,

                 //UserId = driver.UserId,
                 DriverLicenseTypeId = driver.DriverLicenseTypeId,

                 // DriverLicenseType
                 LicenseId = driverlicensetype.Id,
                 LicenseName = driverlicensetype.Name,

             }).ToList();

            return View(result);
        }


        public IActionResult TildelteTure()
        {
            var result =
            (from department in _db.Departments

             join trip in _db.Trips
             on department.Id equals trip.DepartmentId

             join country in _db.Countries
             on trip.StartCountryId equals country.Id

             join endCountry in _db.Countries
             on trip.EndCountryId equals endCountry.Id

             join tripUser in _db.TripUsers
             on trip.Id equals tripUser.TripId

             join user in _db.Users
             on tripUser.UserId equals user.Id

             join driver in _db.Drivers
             on user.Id equals driver.UserId




             select new AssignedTripsVM
                {
                    // Department
                    DepartmentId = department.Id,
                    Name = department.Name,
                    Cvr = department.Cvr,
                    DepartmentPhone = department.Phone,
                    Fax = department.Fax,
                    DepartmentAddressId = department.AddressId,

                    // Trip
                    TripId = trip.Id,
                    StartDate = trip.StartDate,
                    EndDate = trip.EndDate,
                    Priority = trip.Priority,
                    TravelTime = trip.TravelTime,
                    Description = trip.Description,
                    ContactId = trip.ContactId,
                    //DepartmentId = trip.DepartmentId,
                    StartCountryId = trip.StartCountryId,
                    EndCountryId = trip.EndCountryId,

                    // Country
                    Id = country.Id,
                    CountryCode = country.CountryCode,
                    StartCountryCode = country.CountryCode,

                    EndCountryCode = endCountry.CountryCode,

                    // TripUser
                    //TripId = tripUser.TripId,
                    UserId = tripUser.UserId,

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

                    //UserId = driver.UserId,
                    DriverLicenseTypeId = driver.DriverLicenseTypeId,

             }).ToList();

            

        return View(result);
        }

    public IActionResult AfloserOversigt()
        {
            var result =
                (from trip in _db.Trips
                 join tripUser in _db.TripUsers
                 on trip.Id equals tripUser.TripId

                 join user in _db.Users
                 on tripUser.UserId equals user.Id

                 join driver in _db.Drivers
                 on user.Id equals driver.UserId

                 join driverlicensetype in _db.DriverLicenseTypes
                 on driver.DriverLicenseTypeId equals driverlicensetype.Id

                 join driverqualification in _db.DriverQualifications
                 on driver.Id equals driverqualification.DriverId

                 join qualificationtype in _db.QualificationTypes
                 on driverqualification.QualificationTypeId equals qualificationtype.Id

                 select new TripUserDriverQualificationLicenseVM
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
                     Email = user.Email,
                     RoleId = user.RoleId,
                     LoginId = user.LoginId,
                     AddressId = user.AddressId,

                     // Driver
                     DriverId = driver.Id,
                     LicenseExpirationDate = driver.ExpirationDate,
                     UserId = driver.UserId,

                     // DriverLicenseType
                     LicenseId = driverlicensetype.Id,
                     LicenseName = driverlicensetype.Name,
                     
                     // DriverQualification
                     ExpirationDate = driverqualification.ExpirationDate,

                     // QualificationType
                     QualificationId = qualificationtype.Id,
                     QualificationName = qualificationtype.Name,

                 }).ToList();
            return View(result);
        }

    }
}

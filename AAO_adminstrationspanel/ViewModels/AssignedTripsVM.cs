using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_adminstrationspanel.ViewModels
{
    public class AssignedTripsVM
    {
        // Trip
        public int TripId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Priority { get; set; }
        public int? TravelTime { get; set; }
        public string Description { get; set; }
        public int? ContactId { get; set; }
        public int? DepartmentId { get; set; }
        public int? StartCountryId { get; set; }
        public int? EndCountryId { get; set; }

        // Country
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Country1 { get; set; }

        // Department
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cvr { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int? AddressId { get; set; }

        //// TripUser
        //public int TripId { get; set; }
        //public int UserId { get; set; }
        //public bool? Assigned { get; set; }

        // User
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentPhone { get; set; }
        public int? RoleId { get; set; }
        public int? LoginId { get; set; }
        public int? DepartmentAddressId { get; set; }

        // Driver
        public int DriverId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? UserId { get; set; }
        public int? DriverLicenseTypeId { get; set; }

    }
}
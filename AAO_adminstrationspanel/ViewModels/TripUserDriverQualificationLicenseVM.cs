using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_adminstrationspanel.ViewModels
{
    public class TripUserDriverQualificationLicenseVM
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

        // User
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? LoginId { get; set; }
        public int? AddressId { get; set; }

        // Driver
        public int DriverId { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public int? UserId { get; set; }
        public int? DriverLicenseTypeId { get; set; }

        // DriverLicenseType
        public int LicenseId { get; set; }
        public string LicenseName { get; set; }

        // DriverQualification
        public int QualificationTypeId { get; set; }
        public DateTime? ExpirationDate { get; set; }


        // QualificationType
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }

    }
}

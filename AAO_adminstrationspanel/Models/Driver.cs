using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Driver
    {
        public Driver()
        {
            DriverQualifications = new HashSet<DriverQualification>();
        }

        public int Id { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? UserId { get; set; }
        public int? DriverLicenseTypeId { get; set; }

        public virtual DriverLicenseType DriverLicenseType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DriverQualification> DriverQualifications { get; set; }
    }
}

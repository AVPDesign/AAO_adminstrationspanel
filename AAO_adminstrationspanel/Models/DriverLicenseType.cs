using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class DriverLicenseType
    {
        public DriverLicenseType()
        {
            Drivers = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}

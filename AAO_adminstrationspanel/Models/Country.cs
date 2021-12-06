using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            TripEndCountries = new HashSet<Trip>();
            TripStartCountries = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Country1 { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Trip> TripEndCountries { get; set; }
        public virtual ICollection<Trip> TripStartCountries { get; set; }
    }
}

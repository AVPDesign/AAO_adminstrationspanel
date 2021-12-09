using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Drivers = new HashSet<Driver>();
            Schedulers = new HashSet<Scheduler>();
            TripUsers = new HashSet<TripUser>();
            Trips = new HashSet<Trip>();
        }

        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public int? LoginId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Login Login { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Scheduler> Schedulers { get; set; }
        public virtual ICollection<TripUser> TripUsers { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}

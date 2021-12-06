using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Role : IdentityRole<int>
    {
        public Role()
        {
            Drivers = new HashSet<Driver>();
            Schedulers = new HashSet<Scheduler>();
            Users = new HashSet<User>();
        }

        //public int Id { get; set; }
        //public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Scheduler> Schedulers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Department
    {
        public Department()
        {
            Schedulers = new HashSet<Scheduler>();
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cvr { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Scheduler> Schedulers { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}

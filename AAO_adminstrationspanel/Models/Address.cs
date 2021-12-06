using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Address
    {
        public Address()
        {
            Departments = new HashSet<Department>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Address1 { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

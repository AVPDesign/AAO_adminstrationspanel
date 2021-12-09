using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Trip
    {
        public Trip()
        {
            TripUsers = new HashSet<TripUser>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Startdato")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Priority { get; set; }
        public int? TravelTime { get; set; }
        public string Description { get; set; }
        public int? ContactId { get; set; }
        public int? DepartmentId { get; set; }
        public int? StartCountryId { get; set; }
        public int? EndCountryId { get; set; }

        public virtual User Contact { get; set; }
        public virtual Department Department { get; set; }
        public virtual Country EndCountry { get; set; }
        public virtual Country StartCountry { get; set; }
        public virtual ICollection<TripUser> TripUsers { get; set; }
    }
}

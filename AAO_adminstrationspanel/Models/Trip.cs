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

        [Required]
        [Display(Name = "Slutdato")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Hastetur!")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool Priority { get; set; }

        [Required]
        [Display(Name = "Varighed")]
        public int? TravelTime { get; set; }

        [Required]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Kontakt")]
        public int? ContactId { get; set; }

        [Required]
        [Display(Name = "Afdeling")]
        public int? DepartmentId { get; set; }

        [Required]
        [Display(Name = "Trafik fra")]
        public int? StartCountryId { get; set; }

        [Required]
        [Display(Name = "Trafik til")]
        public int? EndCountryId { get; set; }

        public virtual User Contact { get; set; }
        public virtual Department Department { get; set; }
        public virtual Country EndCountry { get; set; }
        public virtual Country StartCountry { get; set; }
        public virtual ICollection<TripUser> TripUsers { get; set; }
    }
}

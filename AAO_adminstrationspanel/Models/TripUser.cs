using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class TripUser
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public bool? Assigned { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual User User { get; set; }
    }
}

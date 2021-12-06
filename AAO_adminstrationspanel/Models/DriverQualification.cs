using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class DriverQualification
    {
        public int QualificationTypeId { get; set; }
        public int DriverId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual QualificationType QualificationType { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class QualificationType
    {
        public QualificationType()
        {
            DriverQualifications = new HashSet<DriverQualification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DriverQualification> DriverQualifications { get; set; }
    }
}

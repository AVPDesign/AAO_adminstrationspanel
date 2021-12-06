using System;
using System.Collections.Generic;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class Scheduler
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}

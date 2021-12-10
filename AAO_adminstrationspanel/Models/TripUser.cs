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



//public class ProjectViewModel
//{
//    public string ProjectName { get; set; }
//    public string Status { set; get; }
//    public int Percent { set; get; }
//}

//var results = (from p in db.Project
//               join ps in db.ProjectStatus on p.Status equals ps.Id
//               select new ProjectViewModel()
//               {
//                   ProjectName = p.ProjectName,
//                   Status = ps.StatusName,
//                   Percent = ps.PercentComplete
//               }).ToList();
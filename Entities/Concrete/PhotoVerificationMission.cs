using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class PhotoVerificationMission:IEntity
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string MissionTitle { get; set; }
        public bool HasTimeLimit { get; set; }
        public int? MissionDuration { get;set; }
        public int SessionDuration { get; set; }
        public string MissionDescription { get; set; }
        public string? PhotoUrl { get; set; }
        public bool Success { get; set; }
        public bool IsApproved { get; set; }

    }
}

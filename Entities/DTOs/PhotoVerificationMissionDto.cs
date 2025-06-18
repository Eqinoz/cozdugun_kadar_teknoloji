using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class PhotoVerificationMissionDto:IDto
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string MissionTitle { get; set; }
        public bool HasTimeLimit { get; set; }
        public int? MissionDuration { get; set; }
        public int SessionDuration { get; set; }
        public string MissionDescription { get; set; }
        public string? PhotoUrl { get; set; }
        public bool Success { get; set; }
        public bool IsApproved { get; set; }
    }
}

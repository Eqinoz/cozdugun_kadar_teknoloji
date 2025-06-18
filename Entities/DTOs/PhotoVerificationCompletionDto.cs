using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class PhotoVerificationCompletionDto:IDto
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string MissionTitle { get;set; }
        public string MissionDescription { get; set; }
        public int SessionDuration { get; set; }
        public string FilePath { get; set; }
        public DateTime AssignedDate { get;set; }
        public DateTime CompletionTime { get; set; }
        public string Description { get; set; }
        public bool Success { get; set; }
        public bool IsApproved { get;set; }
    }
}

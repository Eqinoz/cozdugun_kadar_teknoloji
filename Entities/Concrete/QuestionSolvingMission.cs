using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class QuestionSolvingMission:IEntity
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get;set; }
        public DateTime AssignedDate { get; set; }
        public DateTime VerifiedDate { get; set; }
        public int SchoolLessonId { get;set; }
        public byte SuccessRate { get; set; }
        public uint AllowedTime { get; set; }
        public string Description { get;set; }
        public bool IsApproved { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class QuestionSolvingMissionDto:IDto
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLasttName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime VerifiedDate { get; set; }
        public string SchoolLessonName { get; set; }
        public string EducationStatu { get; set; }
        public short NumberOfQuestion { get; set; }
        public byte SuccessRate { get; set; }
        public int AllowedTime { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class SchoolLessonDto:IDto
    {
        public int Id { get; set; }
        public string EducationStatu { get; set; }
        public string LessonName { get; set; }
    }
}

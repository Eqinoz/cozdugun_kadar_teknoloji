using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class SchoolLesson:IEntity
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string LessonName { get; set; }
    }
}

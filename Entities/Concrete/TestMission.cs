using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    public class TestMission:IEntity
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public int TestCount { get;set; }
        public byte SuccessRate { get;set; }
    }
}

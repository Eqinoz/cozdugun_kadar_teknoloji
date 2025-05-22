using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
   public class MissionAllDto:IDto
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
    }
}

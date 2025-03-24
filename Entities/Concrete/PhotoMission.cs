using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class PhotoMission:IEntity
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public string MissionDescription { get; set; }
        public string ImageUrl { get;set; }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Mission:IEntity
    {
        public int Id { get;set; }
        public int TypeId { get; set; }
        public string Mission_Name { get;set; }
        public string Mission_Description { get;set; }
        public int ParentId { get;set; }
        public int ChildId { get; set; }
        public bool Mission_Check { get; set; }=false;

    }
}

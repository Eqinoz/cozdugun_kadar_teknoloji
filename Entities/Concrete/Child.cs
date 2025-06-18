using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Child:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int ParentId { get; set; }
        public int SchoolsId { get; set; }
        public string ImageUrl { get; set; }
        public int UsageTime { get; set; } = 0;
        public bool UseAuthorization { get; set; }=false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class School :IEntity
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
    }

}

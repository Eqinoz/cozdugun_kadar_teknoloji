using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class ChildDetailsDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string EducationStatu { get; set; }
    }
}

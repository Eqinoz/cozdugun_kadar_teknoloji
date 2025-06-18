using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class PhotoVerificationCompletion:IEntity
    {
        public int Id { get; set; }
        public int ChildId {get; set; }
        public int MissionId { get;set; }
        public string FilePath { get; set; }
        public DateTime CompletionTime { get; set; }
        public int SessionDuration { get; set; }
        public string Description { get; set; }
        public bool Success { get; set; }
        public bool IsApproved { get; set; }
    }
}

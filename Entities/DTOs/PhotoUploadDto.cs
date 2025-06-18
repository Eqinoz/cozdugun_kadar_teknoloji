using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class PhotoUploadDto:IDto
    {
        public int ChildId { get; set; }
        public int MissionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public IFormFile Photo { get; set; } = null!;
    }
}

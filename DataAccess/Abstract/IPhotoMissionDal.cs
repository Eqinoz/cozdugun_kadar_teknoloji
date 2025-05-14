using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IPhotoMissionDal:IEntityRepository<PhotoVerificationMission>
    {
        List<PhotoVerificationMissionDto> GetAllMissionDetails();
        List<PhotoVerificationMissionDto> GetMissionDetailsByParentId(int ParentId);
        List<PhotoVerificationMissionDto> GetMissionDetailsByChildId(int ChildId);
    }
}

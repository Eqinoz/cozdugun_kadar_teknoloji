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
    public interface IPhotoMissionCompletionDal:IEntityRepository<PhotoVerificationCompletion>
    {
        List<PhotoVerificationCompletionDto> GetDetails();
        List<PhotoVerificationCompletionDto> GetDetailsById(int childId);
        PhotoVerificationCompletionDto GetMissionByMissionId(int missionId);
    }
}

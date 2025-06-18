using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoMissionService
    {
        IDataResult<List<PhotoVerificationMission>> GetAllPhotoMissions();
        IDataResult<List<PhotoVerificationMissionDto>> GetAllPhotoMissonDetails();
        IDataResult<List<PhotoVerificationMissionDto>> GetPhotoMissionByParentId(int parentId);
        IDataResult<List<PhotoVerificationMissionDto>> GetPhotoMissionByChildId(int childId);
        IDataResult<PhotoVerificationMissionDto> GetPhotoMissionById(int missionId);

        IResult UpdateMission(int id);
        IResult UpdateSuccess(int id);

        IResult Add(PhotoVerificationMission photoMission);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PhotoMissionManager:IPhotoMissionService
    {
        private IPhotoMissionDal _photoMission;

        public PhotoMissionManager(IPhotoMissionDal photoMission)
        {
            _photoMission=photoMission;
        }
        public IDataResult<List<PhotoVerificationMission>> GetAllPhotoMissions()
        {
            var result = _photoMission.GetAll();
            return new SuccessDataResult<List<PhotoVerificationMission>>(result, "Fotoğraflı Görevler Listendi");
        }

        public IDataResult<List<PhotoVerificationMissionDto>> GetAllPhotoMissonDetails()
        {
            var result = _photoMission.GetAllMissionDetails();
            return new SuccessDataResult<List<PhotoVerificationMissionDto>>(result,
                "Fotoğraflı Görevler Detaylı Listelendi");
        }

        public IDataResult<List<PhotoVerificationMissionDto>> GetPhotoMissionByParentId(int parentId)
        {
            var result = _photoMission.GetMissionDetailsByParentId(parentId);
            return new SuccessDataResult<List<PhotoVerificationMissionDto>>(result,
                "Fotoğraflı Görevler Detaylı Ebeveyne Göre Listelendi");
        }

        public IDataResult<List<PhotoVerificationMissionDto>> GetPhotoMissionByChildId(int childId)
        {
            var result = _photoMission.GetMissionDetailsByChildId(childId);
            return new SuccessDataResult<List<PhotoVerificationMissionDto>>(result,
                "Fotoğraflı Görevler Detaylı Çocuğa Göre Listelendi");
        }

        public IDataResult<PhotoVerificationMissionDto> GetPhotoMissionById(int missionId)
        {
            var result = _photoMission.GetMissionDetailsById(missionId);
            return new SuccessDataResult<PhotoVerificationMissionDto>(result,
                "Görev İd'sine Görev Görev Detayları Getilirdi");
        }

        public IResult Add(PhotoVerificationMission photoMission)
        {
            photoMission.AssignedDate = DateTime.Now;
            photoMission.PhotoUrl = "";
            photoMission.IsApproved=true;

            _photoMission.Add(photoMission);
            return new SuccessResult("Fotoğraflı Görev Başarıyla Eklendi");
        }
    }
}

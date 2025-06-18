using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PhotoMissionCompletionManager:IPhotoMissionCompletionService
    {
        private IPhotoMissionCompletionDal _completionDal;

        public PhotoMissionCompletionManager(IPhotoMissionCompletionDal completionDal)
        {
            _completionDal= completionDal;
        }

        public IDataResult<List<PhotoVerificationCompletion>> GetAll()
        {
            var result = _completionDal.GetAll();
            return new SuccessDataResult<List<PhotoVerificationCompletion>>(result,
                "Tamamlanan Fotoğraflı Görevler Listelendi");
        }

        public IDataResult<PhotoVerificationCompletion> Get(int id)
        {
            var result = _completionDal.Get(x=>x.Id==id);
            return new SuccessDataResult<PhotoVerificationCompletion>(result,"Tamamlanan Görev Id'ye Göre Listelendi");
        }

        public IDataResult<List<PhotoVerificationCompletionDto>> GetAllDetails()
        {
            var result = _completionDal.GetDetails();
            return new SuccessDataResult<List<PhotoVerificationCompletionDto>>(result,"Tamamlanan Görevler Detaylı Listelendi");
        }

        public IDataResult<List<PhotoVerificationCompletionDto>> GetDetailsByChildId(int id)
        {
            var result = _completionDal.GetDetailsById(id);
            return new SuccessDataResult<List<PhotoVerificationCompletionDto>>(result,
                "Çocuğun Tamamlanan Görevleri Listelendi");
        }

        public IDataResult<PhotoVerificationCompletionDto> GetDetailsByMissionId(int id)
        {
            var result = _completionDal.GetMissionByMissionId(id);
            return new SuccessDataResult<PhotoVerificationCompletionDto>(result, "Listelendi");
        }

        public IResult Add(PhotoVerificationCompletion photoVerification)
        {
            _completionDal.Add(photoVerification);
            return new SuccessResult("Görev Tamamlandı");
        }
    }
}

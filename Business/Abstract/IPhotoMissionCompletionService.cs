using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPhotoMissionCompletionService
    {
        IDataResult<List<PhotoVerificationCompletion>> GetAll();
        IDataResult<PhotoVerificationCompletion> Get(int id);
        IDataResult<List<PhotoVerificationCompletionDto>> GetAllDetails();
        IDataResult<List<PhotoVerificationCompletionDto>> GetDetailsByChildId(int id);
        IDataResult<PhotoVerificationCompletionDto> GetDetailsByMissionId(int id);
        IResult Add(PhotoVerificationCompletion photoVerification);
    }
}

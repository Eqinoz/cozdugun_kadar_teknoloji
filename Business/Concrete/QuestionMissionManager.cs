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
    public class QuestionMissionManager:IQuestionMissonService
    {
        private IQuestionMissionDal _questionMission;

        public QuestionMissionManager(IQuestionMissionDal questionMission)
        {
            _questionMission=questionMission;
        }
        public IDataResult<List<QuestionSolvingMission>> GetQuestionSolvingMissions()
        {
            var result = _questionMission.GetAll();
            return new SuccessDataResult<List<QuestionSolvingMission>>(result, "Soru Tipi Görevler Listelendi");
        }

        public IDataResult<List<QuestionSolvingMissionDto>> GetAllQuestionMissionDetails()
        {
            var result = _questionMission.GetAllMissionDetails();
            return new SuccessDataResult<List<QuestionSolvingMissionDto>>(result, "Soru Tipi Görevler Detaylı Listelendi");
        }

        public IDataResult<List<QuestionSolvingMissionDto>> GetQuestionMissionByParentId(int parentId)
        {
            var result = _questionMission.GetMissionDetailsByParentId(parentId);
            return new SuccessDataResult<List<QuestionSolvingMissionDto>>(result, "Soru Tipi Görevler Ebeveyne Göre Listelendi");
        }

        public IDataResult<List<QuestionSolvingMissionDto>> GetQuestionMissionByChildId(int childId)
        {
            var result = _questionMission.GetMissionDetailsByChildId(childId);
            return new SuccessDataResult<List<QuestionSolvingMissionDto>>(result, "Soru Tipi Görevleri Çocuklara Göre Listelendi");
        }

        public IResult Add(QuestionSolvingMission questionMission)
        {
            _questionMission.Add(questionMission);
            return new SuccessResult("Soru Tipi Görev Eklendi");
        }
    }
}

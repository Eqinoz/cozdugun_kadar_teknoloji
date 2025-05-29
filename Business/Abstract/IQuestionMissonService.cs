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
    public interface IQuestionMissonService
    {
        IDataResult<List<QuestionSolvingMission>> GetQuestionSolvingMissions();
        IDataResult<List<QuestionSolvingMissionDto>> GetAllQuestionMissionDetails();
        IDataResult<List<QuestionSolvingMissionDto>> GetQuestionMissionByParentId(int parentId);
        IDataResult<List<QuestionSolvingMissionDto>> GetQuestionMissionByChildId(int childId);
        IDataResult<QuestionSolvingMissionDto> GetQuestionMissionById(int missionId);

        IResult Add(QuestionSolvingMission questionMission);
    }
}

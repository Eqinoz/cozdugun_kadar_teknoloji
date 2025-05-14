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
    public interface IQuestionMissionDal:IEntityRepository<QuestionSolvingMission>
    {
        List<QuestionSolvingMissionDto> GetAllMissionDetails();
        List<QuestionSolvingMissionDto> GetMissionDetailsByParentId(int ParentId);
        List<QuestionSolvingMissionDto> GetMissionDetailsByChildId(int  ChildId);

    }
}

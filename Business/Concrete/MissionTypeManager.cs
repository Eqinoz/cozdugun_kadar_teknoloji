using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MissionTypeManager:IMissionTypeService
    {
        IMissionTypeDal _missionTypeDal;
        public MissionTypeManager(IMissionTypeDal missionTypeDal)
        {
            _missionTypeDal = missionTypeDal;
        }
        public IDataResult<List<MissionType>> GetMissionTypes()
        {
            var result = _missionTypeDal.GetAll();
            return new SuccessDataResult<List<MissionType>>(result, "Görev Tipleri Listelendi");
        }

        public IResult Add(MissionType missionType)
        {
            _missionTypeDal.Add(missionType);
             return new SuccessResult("Görev Tipi Eklendi.");
        }
    }
}

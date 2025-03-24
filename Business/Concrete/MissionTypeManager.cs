using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
        public List<MissionType> GetMissionTypes()
        {
            return _missionTypeDal.GetAll();
        }

        public MissionType Add(MissionType missionType)
        {
             _missionTypeDal.Add(missionType);
            return missionType;
        }
    }
}

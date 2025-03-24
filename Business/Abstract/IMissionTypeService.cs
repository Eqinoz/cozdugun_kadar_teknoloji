using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMissionTypeService
    {
        List<MissionType> GetMissionTypes();
        MissionType Add(MissionType  missionType);
    }
}

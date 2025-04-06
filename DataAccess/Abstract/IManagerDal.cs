using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IManagerDal:IEntityRepository<Manager>
    {
        List<ManagerDetailsDto> GetManagerDetails();
        List<Title> GetTitle(Manager manager);

    }
}

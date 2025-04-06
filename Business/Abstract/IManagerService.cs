using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IManagerService
    {
        IDataResult<List<Manager>> GetAllManager();
        IDataResult<Manager> GetIdManager(int id);
        IDataResult<Manager> GetManagerByMail(string email);
        List<Title> GetTitle(Manager  manager);
        IResult Add(Manager manager);
    }
}

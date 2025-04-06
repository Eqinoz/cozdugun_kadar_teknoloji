using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IParentService
    {
        IDataResult<List<Parent>> GetParentList();
        IDataResult<Parent> GetParentByMail(string  mail);
        IResult Add(Parent parent);
    }
}

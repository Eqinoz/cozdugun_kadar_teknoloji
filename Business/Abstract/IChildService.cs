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
    public interface IChildService
    {
        IDataResult<List<Child>> GetChild();
        IResult Add(Child child);
        IDataResult<List<ChildDetailsDto>> GetChildDetails();
    }
}

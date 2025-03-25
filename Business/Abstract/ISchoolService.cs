using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISchoolService
    {
        IDataResult<List<School>> GetAll();
        IDataResult<School> GetById(int schoolId);
        IResult Add(School school);
    }
}

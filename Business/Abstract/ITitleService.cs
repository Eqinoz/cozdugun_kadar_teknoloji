using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ITitleService
    {
        IDataResult<List<Title>> GetAllTitle();
        IDataResult<Title> GetByIdTitle(int id);
        IDataResult<Title> GetNameByTitle(string  title);
        IResult Add(Title title);
    }
}

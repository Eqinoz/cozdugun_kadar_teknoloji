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
    public interface IChildDal:IEntityRepository<Child>
    {
        List<ChildDetailsDto> ChildDetails();
        ChildDetailsDto GetChildDetailsById(int childId);
        List<ChildDetailsDto> ChildGetByParentId(int id);
    }
}

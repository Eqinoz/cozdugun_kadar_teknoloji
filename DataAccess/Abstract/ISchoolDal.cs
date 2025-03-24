using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISchoolDal:IEntityRepository<School>
    {
        /*
         bunları IEntityRepository Üzerinden İmplement Ediyoruz, generic bir yapıda olduğunda sadece hangi veriyle çalışacağını vermemiz yetiyor.
        //List<School> GetAll();
        //void Add(School school);
        //void Update(School school);
        //void Delete(School school);
        */
    }
}

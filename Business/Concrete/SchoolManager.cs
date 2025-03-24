using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SchoolManager:ISchoolService
    {
        private ISchoolDal _schoolDal;

        public SchoolManager(ISchoolDal schoolDal)
        {
            _schoolDal=schoolDal;
        }
        public List<School> GetAll()
        {
            return _schoolDal.GetAll();
        }

        public School Add(School school)
        {
            _schoolDal.Add(school);
            return school;
        }
    }
}

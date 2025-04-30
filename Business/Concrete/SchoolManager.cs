using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
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
        public IDataResult<List<School>> GetAll()
        {
             
             return new SuccessDataResult<List<School>>(_schoolDal.GetAll(), Messages.SchoolsListed);
        }

        public IDataResult<School> GetById(int schoolId)
        {
            return new DataResult<School>(_schoolDal.Get(s => s.Id == schoolId), true, Messages.SchoolListed);
        }

        public IDataResult<School> GetByName(string schoolName)
        {
            var result = _schoolDal.Get(x => x.SchoolName == schoolName);
            return new SuccessDataResult<School>(result, "Okul Bilgisi Listelendi");
        }

        [SecuredOperation("school.add,Admin")]
        public IResult Add(School school)
        {
            if (school.SchoolName.Length>=5)
            {
                _schoolDal.Add(school);
                return new SuccessResult(Messages.SchoolAdded);
            }

            return new ErrorResult(Messages.SchoolNameInvalid);
        }
    }
}

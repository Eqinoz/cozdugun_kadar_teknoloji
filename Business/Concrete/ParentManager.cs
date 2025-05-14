using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ParentManager:IParentService
    {
        private IParentDal _parentDal;

        public ParentManager(IParentDal parentDal)
        {
            _parentDal = parentDal;
        }
        public IDataResult<List<Parent>> GetParentList()
        {
            var result = _parentDal.GetAll();
            return new SuccessDataResult<List<Parent>>(result,"Başarılı");
        }

        public IDataResult<Parent> GetParentByMail(string mail)
        {
            var result = _parentDal.Get(x => x.Email == mail);
            if (result!=null)
            {
                return new SuccessDataResult<Parent>(result);
            }

            return new ErrorDataResult<Parent>();
        }

        //[ValidationAspect(typeof(ParentValidator))]
        public IResult Add(Parent parent)
        {
           
             _parentDal.Add(parent);
            return new SuccessResult();
        }
    }
}

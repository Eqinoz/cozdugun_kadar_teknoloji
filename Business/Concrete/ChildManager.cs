using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ChildManager:IChildService
    {
        private IChildDal _child;

        public ChildManager(IChildDal childDal)
        {
            _child= childDal;
        }
        public IDataResult<List<Child>> GetChild()
        {
            return new SuccessDataResult<List<Child>>(_child.GetAll());
        }

        public IResult Add(Child child)
        {
            _child.Add(child);
            return new SuccessResult("Başarılı");
        }

        public IDataResult<List<ChildDetailsDto>> GetChildDetails()
        {
            var result = _child.ChildDetails();
            return new SuccessDataResult<List<ChildDetailsDto>>(result,"Başarılı");
        }
    }
}

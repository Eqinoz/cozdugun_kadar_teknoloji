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

        public IDataResult<Child> GetIdChild(int id)
        {
            var result = _child.Get(x => x.Id == id);
            return new SuccessDataResult<Child>(result, "Child List");
        }

        public IDataResult<List<ChildDetailsDto>> GetChildByParentId(int id)
        {
            var result = _child.ChildGetByParentId(id);
            return new SuccessDataResult<List<ChildDetailsDto>>(result, "Ebevenynin Çocukları Listelendi");
        }

        public IResult Add(Child child)
        {
            if (child.ImageUrl == null)
            {
                if (child.Gender=="girl")
                {
                    child.ImageUrl = "https://i.pinimg.com/736x/1a/f4/cd/1af4cd73b5794a1cd0dadfd228adfadf.jpg";
                }
                else if (child.Gender=="boy")
                {
                    child.ImageUrl = "https://i.pinimg.com/736x/2c/8c/8f/2c8c8f777f46b24badd3e9050c796ca4.jpg";

                }
            }
            _child.Add(child);
            return new SuccessResult("Başarılı");
        }

        public IDataResult<List<ChildDetailsDto>> GetChildDetails()
        {
            var result = _child.ChildDetails();
            return new SuccessDataResult<List<ChildDetailsDto>>(result,"Başarılı");
        }

        public IDataResult<ChildDetailsDto> GetChildDetailsById(int id)
        {
            var result = _child.GetChildDetailsById(id);
            return new SuccessDataResult<ChildDetailsDto>(result,"Başarılı");
        }
    }
}

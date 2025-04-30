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
                    child.ImageUrl = "https://weefle.fr/assets/img/profile.webp?h=86dcf74a642f5aaf1d466c4789df7ba5";
                }
                else if (child.Gender=="boy")
                {
                    child.ImageUrl = "https://png.pngtree.com/png-clipart/20220615/original/pngtree-kid-student-back-to-school-in-uniform-wear-backpack-png-image_8043401.png";

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

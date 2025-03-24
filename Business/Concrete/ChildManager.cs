using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
        public List<Child> GetChild()
        {
            return _child.GetAll();
        }

        public Child Add(Child child)
        {
            _child.Add(child);
            return child;
        }

        public List<ChildDetailsDto> GetChildDetails()
        {
            var result = _child.ChildDetails();
            return result;
        }
    }
}

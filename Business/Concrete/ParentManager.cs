using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
        public List<Parent> GetParentList()
        {
            return _parentDal.GetAll();
        }

        public Parent Add(Parent parent)
        {
             _parentDal.Add(parent);
            return parent;
        }
    }
}

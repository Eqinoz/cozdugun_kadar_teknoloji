using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AdminManager:IManagerService
    {
        private IManagerDal _managerDal;

        public AdminManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }
        public IDataResult<List<Manager>> GetAllManager()
        {
            var result = _managerDal.GetAll();
            return new SuccessDataResult<List<Manager>>(result, "Yöneticiler Listelendi");
        }


        public IDataResult<Manager> GetIdManager(int id)
        {
            var result = _managerDal.Get(x => x.Id == id);
            if (result!=null)
            {
                return new SuccessDataResult<Manager>(result, "Yönetici Listelendi");
            }

            return new ErrorDataResult<Manager>("Yönetici Bulunamadı");
        }

        public IDataResult<Manager> GetManagerByMail(string email)
        {
            var result = _managerDal.Get(x => x.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<Manager>(result);
            }

            return new ErrorDataResult<Manager>();
        }

        public List<Title> GetTitle(Manager manager)
        {
            
            return _managerDal.GetTitle(manager);
        }

        public IResult Add(Manager manager)
        {
            _managerDal.Add(manager);
            return new SuccessResult();
        }
    }
}

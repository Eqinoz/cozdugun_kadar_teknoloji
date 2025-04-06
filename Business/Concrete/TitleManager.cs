using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class TitleManager:ITitleService
    {
        private ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }
        public IDataResult<List<Title>> GetAllTitle()
        {
            var result = _titleDal.GetAll();
            return new SuccessDataResult<List<Title>>(result, "Ünvanlar Listelendi");
        }

        public IDataResult<Title> GetByIdTitle(int id)
        {
            var result = _titleDal.Get(x => x.Id == id);
            return new SuccessDataResult<Title>(result, "Ünvan Listelendi");
        }

        public IDataResult<Title> GetNameByTitle(string title)
        {
            var result = _titleDal.Get(x => x.TitleName == title);
            return new SuccessDataResult<Title>(result);
        }

        public IResult Add(Title title)
        {
            _titleDal.Add(title);
            return new SuccessResult("Ünvan Eklendi.");
        }
    }
}

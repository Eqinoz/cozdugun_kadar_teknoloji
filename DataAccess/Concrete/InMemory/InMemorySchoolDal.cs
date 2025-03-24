using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemorySchoolDal:ISchoolDal
    {
        private List<School> _schools;

        public InMemorySchoolDal()
        {
            _schools = new List<School>
            {
                new School{Id = 1,SchoolName = "İlkOkul"},
                new School{Id = 2,SchoolName = "Ortaokul"},
                new School{ Id = 3, SchoolName = "Lise" },
            };
        }
        public List<School> GetAll()
        {
            return _schools;
        }

        public List<School> GetAll(Expression<Func<School, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public School Get(Expression<Func<School, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(School school)
        {
            _schools.Add(school);
        }

        public void Update(School school)
        {
            School schoolUpdate = _schools.SingleOrDefault(x => x.Id == school.Id);
            schoolUpdate.SchoolName= school.SchoolName;
        }

        public void Delete(School school)
        {
            School schoolDelete = _schools.SingleOrDefault(x=>x.Id==school.Id);
            _schools.Remove(schoolDelete);
        }
    }
}

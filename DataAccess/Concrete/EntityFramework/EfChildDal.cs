using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChildDal:EfEntityRepositoryBase<Child,CktDbContext>,IChildDal
    {
        public List<ChildDetailsDto> ChildDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from c in context.Children
                    join
                        p in context.Parents on c.ParentId equals p.Id
                    join s in context.Schools on c.SchoolsId equals s.Id
                    select new ChildDetailsDto
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        ParentFirstName = p.FirstName,
                        ParentLastName = p.LastName,
                        EducationStatu = s.SchoolName
                    };
                return result.ToList();
            }
        }
    }
}

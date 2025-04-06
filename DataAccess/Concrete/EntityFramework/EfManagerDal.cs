using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfManagerDal:EfEntityRepositoryBase<Manager,CktDbContext>,IManagerDal
    {
        public List<ManagerDetailsDto> GetManagerDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from m in context.Managers
                    join t in context.Titles on m.TitleId equals t.Id
                    select new ManagerDetailsDto
                    {
                        Id = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Email = m.Email,
                        PasswordHash = m.PasswordHash,
                        PasswordSalt = m.PasswordSalt,
                        Phone = m.Phone,
                        Title = t.TitleName,
                        Statu = m.Statu
                    };
                return result.ToList();
            }
        }

        public List<Title> GetTitle(Manager manager)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from t in context.Titles
                    where manager.TitleId == t.Id
                    select new Title
                    {
                        Id = t.Id,
                        TitleName = t.TitleName
                    };
                return result.ToList();
            }
        }
    }
}

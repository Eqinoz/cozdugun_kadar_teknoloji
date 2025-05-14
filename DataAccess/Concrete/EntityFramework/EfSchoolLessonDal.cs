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
    public class EfSchoolLessonDal:EfEntityRepositoryBase<SchoolLesson,CktDbContext>,ISchoolLessonDal
    {
        public List<SchoolLessonDto> GetAllDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from sl in context.SchoolsLessons
                    join s in context.Schools on sl.SchoolId equals s.Id
                    select new SchoolLessonDto
                    {
                        Id = sl.Id,
                        EducationStatu = s.SchoolName,
                        LessonName = sl.LessonName,

                    };
                return result.ToList();
            }
        }

        public List<SchoolLessonDto> GetDetailsBySchoolEducationId(int id)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from sl in context.SchoolsLessons
                    join s in context.Schools on sl.SchoolId equals s.Id
                             where s.Id==id
                    select new SchoolLessonDto
                    {
                        Id = sl.Id,
                        EducationStatu = s.SchoolName,
                        LessonName = sl.LessonName,

                    };
                return result.ToList();
            }
        }

        public List<SchoolLessonDto> GetLessonBySchoolName(string schoolName)
        {
            using (CktDbContext context= new CktDbContext())
            {
                var result = from sl in context.SchoolsLessons
                    join s in context.Schools on sl.SchoolId equals s.Id
                    where s.SchoolName == schoolName
                    select new SchoolLessonDto
                    {
                        Id = sl.Id,
                        EducationStatu = s.SchoolName,
                        LessonName = sl.LessonName,

                    };
                return result.ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ISchoolLessonDal:IEntityRepository<SchoolLesson>
    {
        List<SchoolLessonDto> GetAllDetails();
        List<SchoolLessonDto> GetDetailsBySchoolEducationId(int id);
        List<SchoolLessonDto> GetLessonBySchoolName(string  schoolName);
    }
}

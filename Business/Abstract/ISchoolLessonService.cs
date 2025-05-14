using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ISchoolLessonService
    {
        IDataResult<List<SchoolLesson>> GetLessons();
        IDataResult<List<SchoolLessonDto>> GetAllLesson();
        IDataResult<List<SchoolLessonDto>> GetLessonsBySchoolId(int id);
        IDataResult<List<SchoolLessonDto>> GetLessonsBySchoolName(string  schoolName);

        IResult Add(SchoolLesson lesson);
    }
}

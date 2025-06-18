using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class SchoolLessonManager:ISchoolLessonService
    {
        private ISchoolLessonDal _schoolLesson;

        public SchoolLessonManager(ISchoolLessonDal schoolLesson)
        {
            _schoolLesson=schoolLesson;
        }
        public IDataResult<List<SchoolLesson>> GetLessons()
        {
            var result = _schoolLesson.GetAll();
            return new SuccessDataResult<List<SchoolLesson>>(result, "Dersler Listelendi");
        }

        public IDataResult<List<SchoolLessonDto>> GetAllLesson()
        {
            var result = _schoolLesson.GetAllDetails();
            return new SuccessDataResult<List<SchoolLessonDto>>(result, "Dersler Detail Listelendi");
        }

        public IDataResult<List<SchoolLessonDto>> GetLessonsBySchoolId(int id)
        {
            var result = _schoolLesson.GetDetailsBySchoolEducationId(id);
            return new SuccessDataResult<List<SchoolLessonDto>>(result, "Ders Detail Listelendi");
        }

        public IDataResult<List<SchoolLessonDto>> GetLessonsBySchoolName(string schoolName)
        {
            var result = _schoolLesson.GetLessonBySchoolName(schoolName);
            return new SuccessDataResult<List<SchoolLessonDto>>(result, "Ders Detail Listelendi");
        }
        //[SecuredOperation("Admin")]
        public IResult Add(SchoolLesson lesson)
        {
            _schoolLesson.Add(lesson);
            return new SuccessResult("Ders Eklendi");
        }
    }
}

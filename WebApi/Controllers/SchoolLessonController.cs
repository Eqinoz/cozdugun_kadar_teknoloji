using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolLessonController : ControllerBase
    {
        ISchoolLessonService _schoolLessonService;

        public SchoolLessonController(ISchoolLessonService schoolLessonService)
        {
            _schoolLessonService=schoolLessonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result =_schoolLessonService.GetLessons();
            return Ok(result);
        }

        [HttpGet("GetSchoolId")]
        public IActionResult GetSchoolId(int id)
        {
            var result = _schoolLessonService.GetLessonsBySchoolId(id);
            return Ok(result);
        }

        [HttpGet("GetLessonBySchoolName")]
        public IActionResult GetLessonBySchoolName(string schoolName)
        {
            var result = _schoolLessonService.GetLessonsBySchoolName(schoolName);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(SchoolLesson lesson)
        {
           var result = _schoolLessonService.Add(lesson);
           return Ok(result);
        }
    }
}

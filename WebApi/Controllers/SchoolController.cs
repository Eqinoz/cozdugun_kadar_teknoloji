using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _schoolService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetId")]
        public IActionResult Get(int id)
        {
            var result = _schoolService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(School school)
        {
            var result = _schoolService.Add(school);
            return Ok(result);
        }
    }
    
}

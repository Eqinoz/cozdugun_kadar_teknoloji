using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private IChildService _childService;
        private ISchoolService _schoolService;
        private IParentService _parentService;

        public ChildController(IChildService childService,ISchoolService schoolService, IParentService parentService)
        {
            _childService = childService;
            _schoolService=schoolService;
            _parentService = parentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _childService.GetChild();
            return Ok(result);
        }

        [HttpGet("GetDetails")]
        public IActionResult GetDetails()
        {
            var result = _childService.GetChildDetails();
            return Ok(result);
        }
        [HttpGet("GetDetailsById")]
        public IActionResult GetDetailsById(int id)
        {
            var result = _childService.GetChildDetailsById(id);
            return Ok(result);
        }


        [HttpGet("GetId")]
        public IActionResult GetId(int id)
        {
            var result = _childService.GetIdChild(id);
            return Ok(result);
        }

        

        [HttpGet("GetChildByParentId")]
        public IActionResult GetChildByParentId(int parentId)
        {
            var result = _childService.GetChildByParentId(parentId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Child child)
        {
            _childService.Add(child);
            return Ok();
        }

        [HttpPost("ChildRegister")]
        public IActionResult PostDetails(ChildRegisterDto childRegister)
        {
            var schoolId = _schoolService.GetByName(childRegister.EducationStatu);
            Child child = new Child();
            child.FirstName = childRegister.FirstName;
            child.LastName = childRegister.LastName;
            child.Gender=childRegister.Gender;
            child.SchoolsId = schoolId.Data.Id;
            child.ParentId = childRegister.ParentId;

             var result = _childService.Add(child);
            return Ok(result);
        }
    }
}

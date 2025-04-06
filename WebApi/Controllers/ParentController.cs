using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private IParentService _parentDal;
        public ParentController(IParentService parentDal)
        {
            _parentDal=parentDal;
        }

        [HttpGet("GetParent")]
        public IActionResult Get()
        {
            var result = _parentDal.GetParentList();
            return Ok(result);
        }

        [HttpPost("ParentRegister")]
        public IActionResult Post(Parent parent)
        {
            _parentDal.Add(parent);
            return Ok();
        }
    }
}

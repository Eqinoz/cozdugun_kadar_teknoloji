using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService= childService;
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

        [HttpPost]
        public IActionResult Post(Child child)
        {
            _childService.Add(child);
            return Ok();
        }
    }
}

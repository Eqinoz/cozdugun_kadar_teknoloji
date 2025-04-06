using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        IManagerService _manager;

        public ManagerController(IManagerService manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var result= _manager.GetAllManager();
           if (result.Success)
           {
               return Ok(result);
           }
           return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Manager manager)
        {
            var result = _manager.Add(manager);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

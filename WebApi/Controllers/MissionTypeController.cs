using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionTypeController : ControllerBase
    {
        private IMissionTypeService _missionTypeService;

        public MissionTypeController(IMissionTypeService missionTypeService)
        {
            _missionTypeService= missionTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _missionTypeService.GetMissionTypes();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(MissionType missionType)
        {
            var result = _missionTypeService.Add(missionType);
            return Ok(result);
        }
    }
}

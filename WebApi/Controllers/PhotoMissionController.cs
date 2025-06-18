using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoMissionController : ControllerBase
    {
        private IPhotoMissionService _photoMissionService;

        public PhotoMissionController(IPhotoMissionService photoMissionService)
        {
            _photoMissionService = photoMissionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _photoMissionService.GetAllPhotoMissions();
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _photoMissionService.GetAllPhotoMissonDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetDetailsByChildId")]
        public IActionResult GetDetailsByChildId(int id)
        {
            var result = _photoMissionService.GetPhotoMissionByChildId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetDetailsByParentId")]
        public IActionResult GetDetailsByParentId(int id)
        {
            var result = _photoMissionService.GetPhotoMissionByParentId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetMissionById")]
        public IActionResult GetMissionById(int id)
        {
            var result = _photoMissionService.GetPhotoMissionById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("AddPhotoMission")]
        public IActionResult Add(PhotoVerificationMission mission)
        {
            var result = _photoMissionService.Add(mission);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Update")]
        public IActionResult Update(int id)
        {
            var result = _photoMissionService.UpdateMission(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("UploadMissionSuccess")]
        public IActionResult UploadMissionSuccess(int id)
        {
            var result = _photoMissionService.UpdateSuccess(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

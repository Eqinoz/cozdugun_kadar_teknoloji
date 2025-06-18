using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionMissionController : ControllerBase
    {
        private IQuestionMissonService _questionMissonService;

        public QuestionMissionController(IQuestionMissonService questionMissonService)
        {
            _questionMissonService= questionMissonService; 
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _questionMissonService.GetQuestionSolvingMissions();
            if (result.Success)
            {
               return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _questionMissonService.GetAllQuestionMissionDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetDetailsByParentId")]
        public IActionResult GetDetailByParentId(int id)
        {
            var result = _questionMissonService.GetQuestionMissionByParentId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetDetailsByChildId")]
        public IActionResult GetDetailByChildId(int id)
        {
            var result = _questionMissonService.GetQuestionMissionByChildId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetDetailsByMissionId")]
        public IActionResult GetDetailsByMissionId(int id)
        {
            var result = _questionMissonService.GetQuestionMissionById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("UpdateStatus")]
        public IActionResult UpdateStatus(int id)
        {
            var result = _questionMissonService.UpdateMission(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(QuestionSolvingMission mission)
        {
            var result = _questionMissonService.Add(mission);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

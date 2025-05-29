using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionGenerateController : ControllerBase
    {
        private readonly IQuestionGenerateService _generateService;

        public QuestionGenerateController(IQuestionGenerateService generateService)
        {
            _generateService = generateService;
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateQuestion([FromBody] QuestionSolvingMissionDto questionMission)
        {
            var result = await _generateService.QuestionCreate(questionMission);

            if (result.Success)
                return Ok(new { Success = true, Data = result.Data });

            return BadRequest(new { Success = false, Message = result.Message });
        }
    }
}
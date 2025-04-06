using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _titleService.GetAllTitle();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Title title)
        {
            var result = _titleService.Add(title);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

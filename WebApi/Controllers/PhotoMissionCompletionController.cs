using System.Security.Cryptography;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoMissionCompletionController : ControllerBase
    {
        private IPhotoMissionCompletionService _completionService;

        public PhotoMissionCompletionController(IPhotoMissionCompletionService completionService)
        {
            _completionService= completionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _completionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result= _completionService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails(int id)
        {
            var result = _completionService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllDetailsByChildId")]
        public IActionResult GetAllDetailsByChildId(int id)
        {
            var result = _completionService.GetDetailsByChildId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByMissionId")]
        public IActionResult GetByMissionId(int id)
        {
            var result = _completionService.GetDetailsByMissionId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(PhotoVerificationCompletion completionMission)
        {
            var result = _completionService.Add(completionMission);
            if (result.Success==true)
            {
               return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("UploadMissionPhoto")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadMissionPhoto([FromForm] PhotoUploadDto dto)
        {
            try
            {
                if (dto.Photo == null || dto.Photo.Length == 0)
                    return BadRequest("Fotoğraf yok");

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}_{dto.Photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(stream);
                }

                var relativePath = $"uploads/{fileName}";

                var completion = new PhotoVerificationCompletion
                {
                    ChildId = dto.ChildId,
                    MissionId = dto.MissionId,
                    FilePath = relativePath,
                    CompletionTime = DateTime.Now,
                    Description = dto.Description,
                    IsApproved = true

                };

                _completionService.Add(completion);

                return Ok(new { message = "Fotoğraf başarıyla yüklendi", path = relativePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        
    }
}

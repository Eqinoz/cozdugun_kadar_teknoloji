using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("loginManager")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.ManagerLogin(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("registerManager")]
        public ActionResult Register(UserForRegisterDto userForRegister)
        {
            var registerResult = _authService.ManagerRegister(userForRegister, userForRegister.Password);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
            }



            return BadRequest(registerResult);
        }



    }
}

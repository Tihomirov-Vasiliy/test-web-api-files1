using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [ApiVersion("1.0")]
    public class AuthorizationController : ControllerBase
    {
        private IJwtAuthorizationService _authorizationService;

        public AuthorizationController(IJwtAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public ActionResult<ResponseDetails> Login([FromBody] UserDto userDto)
        {
            string token = _authorizationService.Authorize(userDto.Username, userDto.Password);

            return Ok(token);
        }
    }
}

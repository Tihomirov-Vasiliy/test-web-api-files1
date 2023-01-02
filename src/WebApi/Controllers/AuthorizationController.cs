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
        private IJwtAuthorizationService _authenticationService;

        public AuthorizationController(IJwtAuthorizationService authorizationService)
        {
            _authenticationService = authorizationService;
        }

        [HttpPost("login")]
        public ActionResult<ResponseDetails> Login([FromBody] UserDto userDto)
        {
            string token = _authenticationService.Authorize(userDto.Username, userDto.Password);

            return Ok(token);
        }
    }
}

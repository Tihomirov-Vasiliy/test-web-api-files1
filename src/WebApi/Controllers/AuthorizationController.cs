using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/v1/authentication")]
    [ApiController]
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

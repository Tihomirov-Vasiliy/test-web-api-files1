using Application.Interfaces.Services;
using Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.Tests.Authorization
{

    public class JwtAuthorizationServiceTests
    {
        private IJwtAuthorizationService _authorizationService;
        public JwtAuthorizationServiceTests()
        {
            var configurationMock = new Mock<IConfiguration>();
            //setup configuration
            configurationMock.Setup(c => c["Jwt:Key"]).Returns("my top secret key");
            configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("https://localhost:44331");
            configurationMock.Setup(c => c["Jwt:Audience"]).Returns("https://localhost:44331");
            _authorizationService = new Authentication.JwtAuthorizationService(configurationMock.Object);
        }
        [Fact]
        public void ReturnsJwtTokenString()
        {
            Assert.IsType<string>(_authorizationService.Authorize("admin", "admin"));
        }
        [Fact]
        public void ThrowsWrongLoginOrPasswordException()
        {
            Assert.Throws<WrongLoginOrPasswordException>(() => _authorizationService.Authorize("asdafsdgvdxf", "sdfgdfgdf"));
        }
    }
}

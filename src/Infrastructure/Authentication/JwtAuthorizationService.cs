using Application.Interfaces.Services;
using Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JwtAuthorizationService : IJwtAuthorizationService
    {
        private IConfiguration _configuration;

        public JwtAuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <returns>Valid Jwt token</returns>
        /// <exception cref="WrongLoginOrPasswordException">Throws exception when login or password was wrong</exception>
        public string Authorize(string login, string password)
        {
            //Checking if user exist
            User currentUser =
                (UserConstants.User.Username == login && UserConstants.User.Password == password) ?
                UserConstants.User :
                throw new WrongLoginOrPasswordException("Wrong login or password, try different ones");

            //Token creation
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,currentUser.Username)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], //api will validate issuer and audience due to parameters
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
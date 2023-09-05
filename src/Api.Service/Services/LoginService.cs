using Microsoft.IdentityModel.Tokens;
using Api.Domain.Dtos;
using Api.Domain.Security;
using Api.Domain.Repositories;
using Api.Domain.Interfaces.Services.User;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly IConfiguration _configuration;

        public LoginService(
            IUserRepository repository,
            SigningConfigurations signingConfigurations,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email)) return new
            {
                authenticated = false,
                message = "Failed to authenticate user."
            };

            var baseUser = await _repository.FindByLogin(user.Email);

            if (baseUser == null) return new
            {
                authenticated = false,
                message = "Failed to authenticate user."
            };

            var identity = new ClaimsIdentity(
                new GenericIdentity(baseUser.Email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email)
                }
            );

            DateTime createDate = DateTime.Now;
            var secondsToken = Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds"));
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(secondsToken);

            var handler = new JwtSecurityTokenHandler();
            string token = GenerateToken(identity, createDate, expirationDate, handler);

            return SuccessObject(createDate, expirationDate, token, user);
        }

        private string GenerateToken(
            ClaimsIdentity identity,
            DateTime createDate,
            DateTime expirationDate,
            JwtSecurityTokenHandler handler
        )
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(
            DateTime createDate,
            DateTime expirationDate,
            string token,
            LoginDto user
        )
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                message = "User logged in successfully."
            };
        }
    }
}

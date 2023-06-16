using Api.Domain.Entities;
using Application.Dtos.Login;
using Application.Interfaces;
using Domain.Repository;
using Domain.Security;
using Domain.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Application.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;

        public SigningConfigurations _signingConfigurations;
        public IConfiguration _configuration;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations, IConfiguration configuration)
        {
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<Result<object>> FindByLogin(LoginDto user)
        {
            if (user.email != null && !string.IsNullOrWhiteSpace(user.email))
            {
                var baseUser = await _userRepository.FindByLogin(user.email);
                if (baseUser == null)
                {
                    return Result<object>.Failure(new Error(errorName: "Autenticação", "Falha ao autenticar"));
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(baseUser.Email), new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jwt é o Id do token
                        new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email),
                    });
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return Result<object>.Success(SuccessObject(createDate, expirationDate, token, baseUser));
                }
            }
            else
                return Result<object>.Failure();
        }


        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, User user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}
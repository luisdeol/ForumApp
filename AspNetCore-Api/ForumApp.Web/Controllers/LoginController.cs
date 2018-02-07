using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using ForumApp.Web.Models;
using ForumApp.Core;

namespace ForumApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public LoginController(
            SigningConfigurations signingConfiguration,
            TokenConfigurations tokenConfigurations) {
                _signingConfigurations = signingConfiguration;
                _tokenConfigurations = tokenConfigurations;
        }

        [HttpPost]
        public IActionResult Login([FromBody]User user){

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Username, "Login"),
            new []{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            });

             DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok(new {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token
                });
        }
    }
}
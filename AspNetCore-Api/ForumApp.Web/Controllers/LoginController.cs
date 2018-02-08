using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ForumApp.Web.Models;
using ForumApp.Core;
using ForumApp.Core.Interfaces;
using ForumApp.Web.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ForumApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly string ForumUserRole = "ForumUser";
        public readonly string AdminUserRole = "AdminUser";

        public LoginController(
            SigningConfigurations signingConfiguration,
            TokenConfigurations tokenConfigurations,
            UserManager<ApplicationUser> userManager,
            IApplicationUserRepository applicationUserRepository,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _signingConfigurations = signingConfiguration;
            _tokenConfigurations = tokenConfigurations;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]ApplicationUserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, false, false);

            if (!result.Succeeded) return BadRequest("Credenciais Invalidas");

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            claims.AddRange(roles.Select(r=> new Claim(ClaimTypes.Role, r)));

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "Login"),
                claims);

            var dataCriacao = DateTime.Now;
            var dataExpiracao = dataCriacao +
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

            return Ok(new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token
            });
        }

        [HttpPost]
        [Route("/api/register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserDto registrationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = registrationDto.GetApplicationUser();

            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded) return BadRequest(result);

            if (!await _roleManager.RoleExistsAsync(ForumUserRole))
            {
                await _roleManager.CreateAsync(new ApplicationRole
                {
                    Name = ForumUserRole
                });
            }

            await _userManager.AddToRoleAsync(user, ForumUserRole);

            return Ok("Account created");
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardApplication.Options;
using TeamWorkboardData.Users;

namespace TeamWorkboardApplication.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ConfigureOption _configuration;

        public AuthenticationService(
            UserManager<AppUser> userManager,
            IOptions<ConfigureOption> configuration
            )
        {
            _userManager = userManager;
            _configuration = configuration.Value;
        }

        public async Task<string> SignInAsync(SignInDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaim = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,user.Id)
                        };
                foreach (var userRole in userRoles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _configuration.ValidIssuer,
                    audience: _configuration.ValidAudience,
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaim,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                 );
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return token;
            }
            throw new Exception("Account does not exist!!!");
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
            {
                throw new Exception("Account already exist!!!");
            }
            var user = new AppUser()
            {
                PhoneNumber = model.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }
    }
}

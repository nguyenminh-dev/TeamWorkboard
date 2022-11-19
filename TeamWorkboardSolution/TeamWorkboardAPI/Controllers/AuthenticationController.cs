using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TeamWorkboardApplication.Authentications;
using TeamWorkboardData.Users;

namespace TeamWorkboardAPI.Controllers
{
    [Route("api/v1/authentication")]
    [IgnoreAntiforgeryToken]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("sign-in")]
        public async Task<string> SignInAsync([FromBody] SignInDto model)
        {
            var result = await _authenticationService.SignInAsync(model);
            return result;
        }

        [HttpGet("token")]
        [Authorize]
        public async Task<string> TestAsync()
        {
            return "Success";
        }
    }
}

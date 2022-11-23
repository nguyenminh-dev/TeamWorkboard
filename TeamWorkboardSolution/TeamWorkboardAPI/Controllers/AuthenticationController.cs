using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamWorkboardApplication.Authentications;

namespace TeamWorkboardAPI.Controllers
{
    [Route("api/v1/authentication")]
    [IgnoreAntiforgeryToken]
    public class AuthenticationController : TeamWorkboardController
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

        [HttpPost("sign-up")]
        public async Task<IdentityResult> SignUppAsync([FromBody] SignUpDto model)
        {
            var result = await _authenticationService.SignUpAsync(model);
            return result;
        }
    }
}

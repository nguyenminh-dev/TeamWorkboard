using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Threading.Tasks;

namespace TeamWorkboardAPI.Controllers
{
    public abstract class TeamWorkboardController : ControllerBase
    {
        protected TeamWorkboardController()
        {

        }

        protected async Task<string> GetIdUser()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken);
            return jsonToken.Id;
        }
    }
}

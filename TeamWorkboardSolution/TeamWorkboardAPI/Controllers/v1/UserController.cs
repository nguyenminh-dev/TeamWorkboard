using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWorkboardApplication.Teams;
using TeamWorkboardApplication.Users;

namespace TeamWorkboardAPI.Controllers.v1
{
    [Route("api/v1/user")]
    [IgnoreAntiforgeryToken]
    public class UserController : TeamWorkboardController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("getlist")]
        [Authorize]
        public async Task<List<UserDto>> GetList()
        {
            var result = await _userService.GetListAsync();
            return result;
        }
    }
}

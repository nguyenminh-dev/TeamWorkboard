using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWorkboardApplication.Teams;

namespace TeamWorkboardAPI.Controllers.v1
{
    [Route("api/v1/team")]
    [IgnoreAntiforgeryToken]
    public class TeamController : TeamWorkboardController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<TeamDto> CreateAsync([FromBody] TeamCreateDto input)
        {
            var creatorId = await GetIdUser();
            var result = await _teamService.CreateAsync(input, creatorId);
            return result;
        }

        [HttpPost("join")]
        [Authorize]
        public async Task JoinTeamAsync([FromBody] TeamJoinDto input)
        {
            await _teamService.JoinTeam(input);
        }

        [HttpPost("infomation/{id}")]
        [Authorize]
        public async Task<TeamInfomationDto> GetInfomationAsync([FromRoute] string id)
        {
            var result = await _teamService.GetInfomationAsync(id);
            return result;
        }

        [HttpPost("teams-of-user")]
        [Authorize]
        public async Task<List<TeamDto>> GetListTeamOfUserAsync()
        {
            var creatorId = await GetIdUser();
            var result = await _teamService.GetListTeamOfUserAsync(creatorId);
            return result;
        }
    }
}

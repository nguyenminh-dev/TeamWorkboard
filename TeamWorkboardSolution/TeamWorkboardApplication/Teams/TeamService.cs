using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Teams;

namespace TeamWorkboardApplication.Teams
{
    public class TeamService : ITeamService
    {
        private readonly TeamManager _teamManager;
        public TeamService(TeamManager teamManager)
        {
            _teamManager = teamManager;
        }
        public async Task<TeamDto> CreateAsync(TeamCreateDto input)
        {
            var team = new Team(input.Name, "");
            await _teamManager.CreateAsync(team);
            throw new Exception();
        }
    }
}

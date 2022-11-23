using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWorkboardData.Models;

namespace TeamWorkboardData.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamWorkboardDbContext _teamWorkboardDbContext;

        public TeamRepository(TeamWorkboardDbContext teamWorkboardDbContext)
        {
            _teamWorkboardDbContext = teamWorkboardDbContext;
        }
        
        public async Task CreateAsync(Team team)
        {
            _teamWorkboardDbContext.Teams.Add(team);
            await _teamWorkboardDbContext.SaveChangesAsync();
        }

        public async Task<Team> GetAsync(string id)
        {
            var team = await _teamWorkboardDbContext.Teams.FirstOrDefaultAsync(x=> x.Id == id);
            return team;
        }

        public async Task<List<Team>> GetManyAsync(List<string> ids)
        {
            var team = await _teamWorkboardDbContext.Teams.Where(x => ids.Contains(x.Id)).ToListAsync();
            return team;
        }

        public async Task<List<Team>> GetListTeamOfCreatorIdAsync(string creatorId)
        {
            var team = await _teamWorkboardDbContext.Teams.Where(x => x.CreatorId == creatorId).ToListAsync();
            return team;
        }
    }
}

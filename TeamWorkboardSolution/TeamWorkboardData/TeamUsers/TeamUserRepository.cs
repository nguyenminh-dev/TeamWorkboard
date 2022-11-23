using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Models;
using TeamWorkboardData.Teams;

namespace TeamWorkboardData.TeamUsers
{
    public class TeamUserRepository : ITeamUserRepository
    {
        private readonly TeamWorkboardDbContext _teamWorkboardDbContext;

        public TeamUserRepository(TeamWorkboardDbContext teamWorkboardDbContext)
        {
            _teamWorkboardDbContext = teamWorkboardDbContext;
        }

        public async Task<bool> CheckExistAsync(string teamId, string userId)
        {
            var result = await _teamWorkboardDbContext.TeamUsers.AnyAsync(x => x.TeamId == teamId && x.UserId == userId);
            return result;
        }

        public async Task CreateAsync(TeamUser teamUser)
        {
            await _teamWorkboardDbContext.TeamUsers.AddAsync(teamUser);
            await _teamWorkboardDbContext.SaveChangesAsync();
        }

        public async Task CreateManyAsync(List<TeamUser> teamUsers)
        {
            await _teamWorkboardDbContext.TeamUsers.AddRangeAsync(teamUsers);
            await _teamWorkboardDbContext.SaveChangesAsync();
        }

        public async Task<List<string>> GetListTeamIdByUserIdAsync(string userId)
        {
            var result = await _teamWorkboardDbContext.TeamUsers.Where(x => x.UserId == userId).Select(x => x.TeamId).ToListAsync();
            return result;
        }

        public async Task<List<string>> GetListUserIdByTeamIdAsync(string teamId)
        {
            var result = await _teamWorkboardDbContext.TeamUsers.Where(x => x.TeamId == teamId).Select(x => x.UserId).ToListAsync();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardData.TeamUsers
{
    public interface ITeamUserRepository
    {
        Task CreateAsync(TeamUser teamUser);
        Task CreateManyAsync(List<TeamUser> teamUsers);
        Task<bool> CheckExistAsync(string teamId, string userId);
        Task<List<string>> GetListUserIdByTeamIdAsync(string teamId);
        Task<List<string>> GetListTeamIdByUserIdAsync(string userId);
    }
}

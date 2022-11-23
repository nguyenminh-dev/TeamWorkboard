using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardData.Teams
{
    public interface ITeamRepository
    {
        Task CreateAsync(Team team);
        Task<Team> GetAsync(string id);
        Task<List<Team>> GetManyAsync(List<string> ids);
        Task<List<Team>> GetListTeamOfCreatorIdAsync(string creatorId);
    }
}

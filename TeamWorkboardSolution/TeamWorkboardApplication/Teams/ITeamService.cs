using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Teams
{
    public interface ITeamService
    {
        Task<TeamDto> CreateAsync(TeamCreateDto input);
    }
}

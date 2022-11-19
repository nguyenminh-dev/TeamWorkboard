using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Models;

namespace TeamWorkboardData.Teams
{
    public class TeamManager
    {
        private readonly TeamWorkboardDbContext _teamWorkboardDbContext;

        public TeamManager(TeamWorkboardDbContext teamWorkboardDbContext)
        {
            _teamWorkboardDbContext = teamWorkboardDbContext;
        }
        
        public async Task CreateAsync(Team team)
        {
            _teamWorkboardDbContext.Teams.Add(team);
            await _teamWorkboardDbContext.SaveChangesAsync();
        }
    }
}

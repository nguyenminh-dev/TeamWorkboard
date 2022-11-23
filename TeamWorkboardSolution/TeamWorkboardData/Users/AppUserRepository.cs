using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Models;

namespace TeamWorkboardData.Users
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly TeamWorkboardDbContext _teamWorkboardDbContext;

        public AppUserRepository(TeamWorkboardDbContext teamWorkboardDbContext)
        {
            _teamWorkboardDbContext = teamWorkboardDbContext;
        }
        public async Task<List<AppUser>> GetByIdsAsync(List<string> ids)
        {
            var result = await _teamWorkboardDbContext.Users.Where(x => ids.Contains(x.Id)).ToListAsync();
            return result;
        }

        public async Task<List<AppUser>> GetListAsync()
        {
            var result = await _teamWorkboardDbContext.Users.ToListAsync();
            return result;
        }

    }
}

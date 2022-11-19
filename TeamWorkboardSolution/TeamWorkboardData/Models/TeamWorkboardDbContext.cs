using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Teams;
using TeamWorkboardData.TeamUsers;
using TeamWorkboardData.Users;

namespace TeamWorkboardData.Models
{
    public class TeamWorkboardDbContext : IdentityDbContext<AppUser>
    {
        public TeamWorkboardDbContext(DbContextOptions<TeamWorkboardDbContext> options) : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers{ get; set; }
    }
}

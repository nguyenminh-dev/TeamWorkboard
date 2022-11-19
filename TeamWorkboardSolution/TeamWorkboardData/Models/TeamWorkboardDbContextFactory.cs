using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardData.Models
{
    public class TeamWorkboardDbContextFactory : IDesignTimeDbContextFactory<TeamWorkboardDbContext>
    {
        public TeamWorkboardDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeamWorkboardDbContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=TeamWorkboard;Trusted_Connection=True;");
            return new TeamWorkboardDbContext(optionsBuilder.Options);
        }
    }
}

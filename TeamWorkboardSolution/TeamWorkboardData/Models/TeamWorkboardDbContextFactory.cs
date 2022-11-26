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
            optionsBuilder.UseSqlServer("Server=mysql://bc0dd1ac8759d4:970074ec@us-cdbr-east-06.cleardb.net/heroku_a2abb582c1ac05b?reconnect=true");
            return new TeamWorkboardDbContext(optionsBuilder.Options);
        }
    }
}

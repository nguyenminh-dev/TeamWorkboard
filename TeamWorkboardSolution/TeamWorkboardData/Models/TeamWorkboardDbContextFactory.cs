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
            var connUrl = "mysql://bc0dd1ac8759d4:970074ec@us-cdbr-east-06.cleardb.net/heroku_a2abb582c1ac05b?reconnect=true";
            connUrl = connUrl.Replace("mysql://", string.Empty);
            var userPassSide = connUrl.Split("@")[0];
            var hostSide = connUrl.Split("@")[1];

            var connUser = userPassSide.Split(":")[0];
            var connPass = userPassSide.Split(":")[1];
            var connHost = hostSide.Split("/")[0];
            var connDb = hostSide.Split("/")[1].Split("?")[0];
            var connStr = $"Server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";
            optionsBuilder.UseSqlServer(connStr);
            return new TeamWorkboardDbContext(optionsBuilder.Options);
        }
    }
}

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
            optionsBuilder.UseSqlServer("Server=cwe1u6tjijexv3r6.cbetxkdyhwsb.us-east-1.rds.amazonaws.com:3306;Uid=pb4uh3jbk86s8fla;Pwd=aoseznri4qxnnknf;Database=detlxbz625ztquy9");
            return new TeamWorkboardDbContext(optionsBuilder.Options);
        }
    }
}

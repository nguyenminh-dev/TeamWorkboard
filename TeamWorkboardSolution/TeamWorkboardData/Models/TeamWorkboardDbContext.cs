using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Users;

namespace TeamWorkboardData.Models
{
    public class TeamWorkboardDbContext : IdentityDbContext<AppUser>
    {
        public TeamWorkboardDbContext(DbContextOptions<TeamWorkboardDbContext> options) : base(options)
        {

        }
       
    }
}

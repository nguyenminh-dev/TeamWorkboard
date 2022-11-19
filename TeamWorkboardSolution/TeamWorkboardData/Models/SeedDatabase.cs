using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Models;
using TeamWorkboardData.Users;

namespace TeamWorkboardData.Models
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TeamWorkboardDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new AppUser()
                {
                    UserName = "Admin",
                    PhoneNumber = "88888888",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Password = "Admin@123",
                };
                userManager.CreateAsync(user, "Admin@123");
            }
        }
    }
}

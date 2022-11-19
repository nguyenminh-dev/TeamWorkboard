using Microsoft.AspNetCore.Identity;

namespace TeamWorkboardData.Users
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; }
    }
}

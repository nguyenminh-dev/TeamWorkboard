using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Users;

namespace TeamWorkboardApplication.Authentications
{
    public interface IAuthenticationService
    {
        Task<string> SignInAsync(SignInDto model);
        Task<IdentityResult> SignUpAsync(SignUpDto model);

    }
}

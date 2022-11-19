using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Authentications
{
    public interface IAuthenticationService
    {
        Task<string> SignInAsync(SignInDto model);
    }
}

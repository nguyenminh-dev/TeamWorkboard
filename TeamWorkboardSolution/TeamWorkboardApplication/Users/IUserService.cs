﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Users
{
    public interface IUserService
    {
        Task<List<UserDto>> GetListAsync();
    }
}

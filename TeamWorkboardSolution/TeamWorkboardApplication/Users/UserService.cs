using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardData.Teams;
using TeamWorkboardData.Users;

namespace TeamWorkboardApplication.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserRepository _appUserRepository;

        public UserService(UserManager<AppUser> userManager, IAppUserRepository appUserRepository)
        {
            _userManager = userManager;
            _appUserRepository=appUserRepository;
        }
        public async Task<List<UserDto>> GetListAsync()
        {
            var users = await _appUserRepository.GetListAsync();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AppUser, UserDto>()
                );
            var mapper = new Mapper(config);
            var result = mapper.Map<List<AppUser>, List<UserDto>>(users);
            return result;
        }
    }
}

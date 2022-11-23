using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardApplication.Users;
using TeamWorkboardData.Teams;
using TeamWorkboardData.TeamUsers;
using TeamWorkboardData.Users;

namespace TeamWorkboardApplication.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamUserRepository _teamUserRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        public TeamService(
            ITeamRepository teamRepository,
            ITeamUserRepository teamUserRepository,
            IAppUserRepository appUserRepository,
            UserManager<AppUser> userManager
            )
        {
            _teamRepository = teamRepository;
            _teamUserRepository = teamUserRepository;
            _appUserRepository = appUserRepository;
            _userManager = userManager;
        }

        public async Task<TeamDto> CreateAsync(TeamCreateDto input, string creatorId)
        {
            var team = new Team(input.Name, creatorId);
            await _teamRepository.CreateAsync(team);
            var result = new TeamDto(team.Id, team.Name, team.CreatorId);
            return result;
        }

        public async Task JoinTeam(TeamJoinDto input)
        {
            var teamUsers = new List<TeamUser>();
            var team = await _teamRepository.GetAsync(input.TeamId);
            foreach (var item in input.UserIds)
            {
                var user = await _userManager.FindByIdAsync(item);
                if (item != team.CreatorId && user !!= null && (await _teamUserRepository.CheckExistAsync(input.TeamId, item) == false))
                {
                    var teamUser = new TeamUser(item, input.TeamId);
                    teamUsers.Add(teamUser);
                }
            }
            await _teamUserRepository.CreateManyAsync(teamUsers);
        }

        public async Task<TeamInfomationDto> GetInfomationAsync(string id)
        {
            
            var team = await _teamRepository.GetAsync(id);
            if(team == null)
            {
                throw new Exception("Team does not exist!!!");
            }
            var leaderTeam = await _userManager.FindByIdAsync(team.CreatorId);
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AppUser, UserDto>()
                );
            var mapper = new Mapper(config);
            var leader = mapper.Map<AppUser, UserDto>(leaderTeam);
            var memberTeamIds = await _teamUserRepository.GetListUserIdByTeamIdAsync(team.Id);
            var memberTeams = await _appUserRepository.GetByIdsAsync(memberTeamIds);
            var member = mapper.Map<List<AppUser>, List<UserDto>>(memberTeams);
            var result = new TeamInfomationDto(team.Id, team.Name, team.CreatorId, leader, member, member.Count + 1);
            return result;
        }

        public async Task<List<TeamDto>> GetListTeamOfUserAsync(string userId)
        {
            var teams = new List<Team>();
            var teamUserIsAdmins = await _teamRepository.GetListTeamOfCreatorIdAsync(userId);
            if(teamUserIsAdmins != null)
            {
                teams.AddRange(teamUserIsAdmins);
            }
            var teamIds = await _teamUserRepository.GetListTeamIdByUserIdAsync(userId);
            var teamUserIsMembers = await _teamRepository.GetManyAsync(teamIds);
            if (teamUserIsMembers != null)
            {
                teams.AddRange(teamUserIsMembers);
            }
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Team, TeamDto>()
                );
            var mapper = new Mapper(config);
            var result = mapper.Map<List<Team>, List<TeamDto>>(teams);
            return result;
        }
    }
}

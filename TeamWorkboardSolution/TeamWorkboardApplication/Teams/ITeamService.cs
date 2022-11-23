using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Teams
{
    public interface ITeamService
    {
        /// <summary>
        /// Tạo 1 team
        /// </summary>
        /// <param name="input"></param>
        /// <param name="creatorId"></param>
        /// <returns></returns>
        Task<TeamDto> CreateAsync(TeamCreateDto input, string creatorId);
        /// <summary>
        /// Thêm thành viên vào 1 team
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task JoinTeam(TeamJoinDto input);
        /// <summary>
        /// Lấy thông tin của 1 team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeamInfomationDto> GetInfomationAsync(string id);
        Task<List<TeamDto>> GetListTeamOfUserAsync(string userId); 

    }
}

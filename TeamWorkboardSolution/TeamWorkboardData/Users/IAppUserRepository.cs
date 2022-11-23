using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardData.Users
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetByIdsAsync(List<string> ids);
        Task<List<AppUser>> GetListAsync();
    }
}

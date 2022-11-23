using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWorkboardApplication.Users;
using TeamWorkboardData.Users;

namespace TeamWorkboardApplication.Teams
{
    public class TeamInfomationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public UserDto Admin { get; set; }
        public List<UserDto> Users { get; set; }
        public long? TotolMember { get; set; }
        public TeamInfomationDto(string id, string name, string creatorId, UserDto admin, List<UserDto> users, long? totolMember)
        {
            Id=id;
            Name=name;
            CreatorId=creatorId;
            Admin=admin;
            Users=users;
            TotolMember=totolMember;
        }
    }
}

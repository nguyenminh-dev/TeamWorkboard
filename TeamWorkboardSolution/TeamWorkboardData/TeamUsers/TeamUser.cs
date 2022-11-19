using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamWorkboardData.TeamUsers
{
    public class TeamUser
    {
        public string Id { get; private set; }
        public string UserId { get; set; }
        public string TeamId { get; set; }

        public TeamUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardData.Teams
{
    public class Team
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public Team(string name, string creatorId)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            CreatorId = creatorId;
        }
    }
}

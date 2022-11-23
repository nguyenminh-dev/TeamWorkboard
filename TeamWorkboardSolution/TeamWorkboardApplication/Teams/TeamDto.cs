using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Teams
{
    public class TeamDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public TeamDto(string id, string name, string creatorId)
        {
            Id = id;
            Name = name;
            CreatorId = creatorId;
        }
    }
}

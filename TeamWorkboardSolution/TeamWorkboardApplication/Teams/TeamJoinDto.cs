using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkboardApplication.Teams
{
    public class TeamJoinDto
    {
        public string TeamId { get; set; }
        public List<string> UserIds { get; set; }
    }
}

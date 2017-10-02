using System.Collections.Generic;

namespace Redmine_for_dummies.Models
{
    public class TFSTeamsResponse
    {
        public int Count { get; set; }
        public List<TFSTeam> Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine_for_dummies.Models
{
    public class TFSProjectResponse
    {
        public int count { get; set; }
        public List<TfsProject> value { get; set; }
    }
}

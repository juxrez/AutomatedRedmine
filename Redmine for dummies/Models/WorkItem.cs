using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine_for_dummies.Models
{
    public class WorkItem
    {
        public string Description { get; set; }
        public string State { get; set; }
        public string Iteration { get; set; }
    }
}

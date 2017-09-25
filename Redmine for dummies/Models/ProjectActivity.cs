using Redmine_for_dummies.Catalog;
using System;

namespace Redmine_for_dummies.Models
{
    public class ProjectActivity
    {
        public string IssueNumber { get; set; }

        public DateTime Date { get; set; }

        public decimal Hours { get; set; }

        public string Comment { get; set; }

        public Activity Activity { get; set; }

        public ProjectActivity()
        {

        }
    }
}

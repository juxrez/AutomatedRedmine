using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine_for_dummies
{
    public interface IRedmineDriver
    {
        void Start();
        bool Login();
        bool OpenProject(string issueNumber);
        void Close();
        bool LogEntry();
    }
}

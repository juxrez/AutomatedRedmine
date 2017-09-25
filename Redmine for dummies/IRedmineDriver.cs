using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine_for_dummies
{
    public interface IRedmineDriver
    {
        void Login(string username, string password);
        
    }
}

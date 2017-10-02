
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

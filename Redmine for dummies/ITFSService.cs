using Redmine_for_dummies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redmine_for_dummies
{
    public interface ITFSService
    {
        Task<TFSProjectResponse> GetProjects();
        Task<TFSTeamsResponse> GetTeams(TfsProject project);
        Task<TfsIterationsResponse> GetITerations(TFSTeam team, TfsProject project);
        List<WorkItem> GetTFSItems(TfsProject project, string iteration);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine_for_dummies.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;

namespace Redmine_for_dummies
{
    public class TFSService : ITFSService
    {
        public string PersonalAccessToken { get; set; }

        public TFSService(string personalAccessToken)
        {
            PersonalAccessToken = personalAccessToken;
        }
        public async Task<TfsIterationsResponse> GetITerations(TFSTeam team, TfsProject project)
        {
            Uri uri = new Uri("https://bofaz.visualstudio.com/");
            var iterations = new TfsIterationsResponse();
            var tokenString = Convert.ToBase64String(
                        System.Text.Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", PersonalAccessToken)));

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", tokenString);

                using (HttpResponseMessage response = client.GetAsync(
                               $"{uri.ToString()}{project.Id}/{team.Id}/_apis/work/teamsettings/iterations").Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                     iterations = JsonConvert.DeserializeObject<TfsIterationsResponse>(responseBody);
                }

                return iterations;
            }
        }

        public async Task<TFSProjectResponse> GetProjects()
        {

            if (!string.IsNullOrEmpty(PersonalAccessToken))
            {
                var projects = new TFSProjectResponse();
                var tokenString = Convert.ToBase64String(
                            System.Text.Encoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", PersonalAccessToken)));

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", tokenString);

                    using (HttpResponseMessage response = client.GetAsync(
                                "https://bofaz.visualstudio.com/DefaultCollection/_apis/projects").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        projects = JsonConvert.DeserializeObject<TFSProjectResponse>(responseBody);
                        return projects;
                    }
                }
            }

            throw new Exception("Invalid Token");
        }

        public async Task<TFSTeamsResponse> GetTeams(TfsProject project)
        {
            var teams = new TFSTeamsResponse();
                var tokenString = Convert.ToBase64String(
                         System.Text.Encoding.ASCII.GetBytes(
                             string.Format("{0}:{1}", "", PersonalAccessToken)));
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", tokenString);

                using (HttpResponseMessage response = client.GetAsync(
                              $"https://bofaz.visualstudio.com/_apis/projects/{project.Id}/teams?%24top=500&%24skip=0").Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    teams = JsonConvert.DeserializeObject<TFSTeamsResponse>(responseBody);
                }
            }

            return teams;
        }

        public List<Models.WorkItem> GetTFSItems(TfsProject project, string iteration)
        {
            VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
            Uri uri = new Uri("https://bofaz.visualstudio.com/");
            var items = new List<Models.WorkItem>();
            Wiql wiql = new Wiql()
            {
                Query = "Select [System.State], [System.Title], [System.Id]" +
                      "From WorkItems " +
                      "WHERE [System.TeamProject] = '" + project.Name + "' " +
                      "AND [System.IterationPath] = '" + iteration + "' " +
                      "AND [System.AssignedTo] = @Me "
            };

            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                //execute the query to get the list of work items in the results
                WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;

                //some error handling                
                if (workItemQueryResult.WorkItems.ToList().Count != 0)
                {
                    //need to get the list of our work item ids and put them into an array
                    List<int> list = new List<int>();
                    foreach (var item in workItemQueryResult.WorkItems)
                    {
                        list.Add(item.Id);
                    }
                    int[] arr = list.ToArray();

                    //build a list of the fields we want to see
                    string[] fields = new string[3];
                    fields[0] = "System.Id";
                    fields[1] = "System.Title";
                    fields[2] = "System.State";

                    //get work items for the ids found in query
                    var workItems = workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf).Result;

                    //loop though work items and write to console
                    foreach (var workItem in workItems)
                    {
                        var it = new Models.WorkItem()
                        {
                            Description = workItem.Fields["System.Title"].ToString(),
                            State = workItem.Fields["System.State"].ToString(),
                            Iteration = iteration,
                        };

                        items.Add(it);
                    }
                }
            }

            return items;
        }
    }
}

using System;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Redmine_for_dummies.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Redmine_for_dummies
{
    public partial class MainWindow : Form
    {
        private IRedmineDriver driver;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            var loginWindow = new LoginCredentialsWindows();
            DialogResult confirmationBox = MessageBox.Show("Are you sure your time entries are correct?", "Warining", MessageBoxButtons.YesNo);

            if (confirmationBox == DialogResult.Yes)
            {
                var dialogStatus = loginWindow.ShowDialog(this);

                if (!string.IsNullOrEmpty(loginWindow.EmailTextBox) || !string.IsNullOrEmpty(loginWindow.PasswordTextBox))
                {
                    try
                    {
                        var data = (List<ProjectActivity>)dataGridView.DataSource;
                        driver = new RedmineDriver(loginWindow.EmailTextBox, loginWindow.PasswordTextBox, data);
                        driver.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter your credentials", "Error");
            }
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void Data_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    var data = LoadJson(filePath);
                    dataGridView.DataSource = data;
                    btnCredentials.Enabled = true;
                }
                catch (IOException)
                {
                    MessageBox.Show("Something went wrong, please try again.","Error", MessageBoxButtons.OK);
                }
            }
        }

        private List<ProjectActivity> LoadJson(string filePath)
        {
            var data = new List<ProjectActivity>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<ProjectActivity>>(json);
            }

            return data;
        }

        private void chkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxEdit.Checked == true)
                dataGridView.Enabled = true;
            else
                dataGridView.Enabled = false;

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
                driver.Close();
        }

        private void btnTFS_Click(object sender, EventArgs e)
        {
            
            Uri uri = new Uri("https://bofaz.visualstudio.com/OnLine%20Banking/UDB_Forms_Docs/");
            string personalAccessToken = "bokutsf6txhkvv3dikofobrjys6eq4jp5einq47mkqup6mk2cy6q";
            string project = "OnLine Banking";
            VssBasicCredential credentials = new VssBasicCredential("", personalAccessToken);
            string iteration = @"OnLine Banking\UDB-30 (09.18-10.01)";

            Wiql wiql = new Wiql()
            {
                Query = "Select [System.State], [System.Title] " +
                      "From WorkItems " +
                      "WHERE [System.TeamProject] = 'OnLine Banking' " +
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

                    Console.WriteLine("Query Results: {0} items found", workItems.Count);
                    var items = new List<Models.WorkItem>();
                    //loop though work items and write to console
                    foreach (var workItem in workItems)
                    {
                        var it = new Models.WorkItem()
                        {
                            Description = workItem.Fields["System.Title"].ToString(),
                            State = workItem.Fields["System.State"].ToString(),
                            Iteration = iteration
                        };
                        items.Add(it);
                    }

                    dataGridView.DataSource = items;
                }

                //return null;
            }

        }

        private async void btnToken_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtToken.Text))
            {
                var personalaccesstoken = "bokutsf6txhkvv3dikofobrjys6eq4jp5einq47mkqup6mk2cy6q";
                var tokenString = Convert.ToBase64String(
                            System.Text.Encoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken)));
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
                        var projects = JsonConvert.DeserializeObject<TFSProjectResponse>(responseBody);
                        var projectNames = new List<string>();
                        foreach (var p in projects.value)
                        {
                            projectNames.Add(p.name);
                        }
                        comboProjects.DataSource = projectNames;
                    }
                }
            }
        }
        //TODO find seleced project in combo box
        private void comboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = 1;
            
        }
    }
}

using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Redmine_for_dummies.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Redmine_for_dummies
{
    public partial class MainWindow : Form
    {
        private IRedmineDriver _driver;
        private ITFSService tfsService;

        public MainWindow()
        {
            InitializeComponent();
            tfsService = new TFSService("bokutsf6txhkvv3dikofobrjys6eq4jp5einq47mkqup6mk2cy6q");
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            var loginWindow = new LoginCredentialsWindows();
            DialogResult confirmationBox = MessageBox.Show("Are you sure your time entries are correct?", "Warining", MessageBoxButtons.YesNo);

            if (confirmationBox == DialogResult.Yes)
            {
                var loginDialogStatus = loginWindow.ShowDialog(this);

                if (loginWindow.PasswordTextBox != null)
                {
                    try
                    {
                        var data = (BindingList<ProjectActivity>)dataGridView.DataSource;
                        _driver = new RedmineDriver(loginWindow.EmailTextBox, loginWindow.PasswordTextBox, data.ToList(), loginWindow.IssueTextBox);
                        _driver.Login();
                        _driver.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = new List<ProjectActivity>();
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
                    MessageBox.Show("Something went wrong, please try again.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private BindingList<ProjectActivity> LoadJson(string filePath)
        {
            var data = new BindingList<ProjectActivity>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<BindingList<ProjectActivity>> (json);
            }

            return data;
        }

        private void chkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEdit.Checked == true)
                dataGridView.Enabled = true;
            else
                dataGridView.Enabled = false;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_driver != null)
                _driver.Close();
        }

        //ToDo: figure out the current iteration and project and Token
        private  void btnTFS_Click(object sender, EventArgs e)
        {
            var project = (TfsProject)comboProjects.SelectedItem;
            var team = (TFSTeam)comboTeams.SelectedItem;
            var iteration = tfsService.GetITerations(team, project).Result.Value.LastOrDefault().Path;
            var items = tfsService.GetTFSItems(project, iteration);
            FillDataGrid(items);
        }

        private void btnToken_Click(object sender, EventArgs e)
        {
            var projects = tfsService.GetProjects();
            comboProjects.DataSource = projects.Result.Value;
            comboProjects.DisplayMember = "Name";
        }

        private void comboProjects_DataSourceChanged(object sender, EventArgs e)
        {
            var x = comboProjects.SelectedItem;
            btnGetTeams.Enabled = true;
        }

        private void btnGetTeams_Click(object sender, EventArgs e)
        {
            var project = (TfsProject)comboProjects.SelectedItem;
            var teams = tfsService.GetTeams(project).Result;
            comboTeams.DataSource = teams.Value;
            comboTeams.DisplayMember = "Name";
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(item.Index);
            }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var result = MessageBox.Show("Do you want to delete this row?", "Warning", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                    {
                        if (oneCell.Selected)
                            dataGridView.Rows.RemoveAt(oneCell.RowIndex);
                    }
                }
            }
        }

        private void FillDataGrid(List<Models.WorkItem> data)
        {
            var workItems = new BindingList<ProjectActivity>();

            foreach (var item in data)
            {
                var workItem = new ProjectActivity()
                {
                    Activity = Catalog.Activity.Development,
                    Comment = item.Description,
                };

                workItems.Add(workItem);
            }

            dataGridView.DataSource = workItems;
        }
    }
}

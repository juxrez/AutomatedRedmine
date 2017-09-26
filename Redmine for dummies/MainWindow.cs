using System;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Redmine_for_dummies.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            var dialogStatus = loginWindow.ShowDialog(this);
           
            if (!string.IsNullOrEmpty(loginWindow.EmailTextBox) || !string.IsNullOrEmpty(loginWindow.PasswordTextBox))
            {
                driver = new RedmineDriver(loginWindow.EmailTextBox, loginWindow.PasswordTextBox);
                var successLogin = driver.Login();

            }
            else
                MessageBox.Show("Please enter your credentials");
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
                    LogButton.Enabled = true;
                }
                catch (IOException)
                {
                    MessageBox.Show("Something went wrong, please try again.");
                }
            }
        }

        public List<ProjectActivity> LoadJson(string filePath)
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
    }
}

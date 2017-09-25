using System;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Redmine_for_dummies.Models;
using System.Collections.Generic;

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
            driver = new RedmineDriver();

            driver.Login(txtEmail.Text, txtPassword.Text);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        
        }

        private void Data_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    var data = LoadJson(filePath);
                    dataGridView1.DataSource = data;
                }
                catch (IOException)
                {
                }
            }

        }

        public List<ProjectActivity> LoadJson(string filePath)
        {
            var data = new List<ProjectActivity>();
            using (StreamReader r = new StreamReader(filePath))//($@"C:\Users\ajuarez\Documents\visual studio 2015\Projects\Redmine for dummies\Redmine for dummies\TestData.json"))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<ProjectActivity>>(json);
            }
            return data;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
        }
    }
}

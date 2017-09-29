using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine_for_dummies.Models;

namespace Redmine_for_dummies
{
    public  class RedmineDriver : IRedmineDriver
    {
        public string RedmineUrl => "https:\\dev.unosquare.com";
        public IWebDriver WebDriver = new ChromeDriver();
        public string  Username { get; set; }
        public string Password { get; set; }
        public List<ProjectActivity> ProjectActivities { get; set; }

        public RedmineDriver(string username, string password, List<ProjectActivity> activities)
        {
            WebDriver.Url = RedmineUrl;
            Username = username;
            Password = password;
            ProjectActivities = activities; 
        }

        public bool Login()
        {
            WebDriver.FindElement(By.Name("username")).SendKeys(Username);
            WebDriver.FindElement(By.Name("password")).SendKeys(Password);
            WebDriver.FindElement(By.Name("login")).Click();

            if (string.Equals(WebDriver.PageSource, "https://dev.unosquare.com/redmine/"))
                return true; 

            return false;
        }

        public bool OpenProject(string issueNumber)
        {
            var issueUrl = $"https://dev.unosquare.com/redmine/issues/{issueNumber}/time_entries/new";
            WebDriver.Navigate().GoToUrl(issueUrl);

            if (WebDriver.PageSource.Equals(issueUrl))
                return true;
            return false;
        }
        public void Close()
        {
            WebDriver.Quit();
        }

        public bool LogEntry()
        {
            WebDriver.FindElement(By.Id("time_entry_spent_on")).SendKeys("10/25/2017");
            return true;
        }

        public void Start()
        {
            if (ProjectActivities == null || ProjectActivities.Count == 0)
                throw new Exception("No data to entry");

            try
            {
                var successLogin = Login();
                var openProject = OpenProject(ProjectActivities.FirstOrDefault().IssueNumber);
                var logEntry = LogEntry();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

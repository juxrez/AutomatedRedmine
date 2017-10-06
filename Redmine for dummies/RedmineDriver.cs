using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Redmine_for_dummies.Models;
using OpenQA.Selenium.Support.UI;
using Redmine_for_dummies.Catalog;

namespace Redmine_for_dummies
{
    //TODO: Hide redmine URL
    public  class RedmineDriver : IRedmineDriver
    {
        public string RedmineUrl => "https:\\dev.unosquare.com";
        public IWebDriver WebDriver = new ChromeDriver();
        public string  Username { get; set; }
        public string Password { get; set; }
        public string IssueNumber { get; set; }
        public List<ProjectActivity> ProjectActivities { get; set; }

        public RedmineDriver(string username, string password, List<ProjectActivity> activities, string issueNumber)
        {
            WebDriver.Url = RedmineUrl;
            Username = username;
            Password = password;
            IssueNumber = issueNumber;
            ProjectActivities = activities; 
        }

        public bool Login()
        {
            WebDriver.FindElement(By.Name("username")).SendKeys(Username);
            WebDriver.FindElement(By.Name("password")).SendKeys(Password);
            WebDriver.FindElement(By.Name("login")).Click();

            if (string.Equals(WebDriver.PageSource, "https://dev.unosquare.com/redmine/"))
                return true;

            throw new Exception("Invalid Credentials");
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
            WebDriver.Close();
            WebDriver.Quit();
        }

        public bool LogEntry(ProjectActivity activity)
        {
            var s = Enum.GetName(typeof(Activity), activity.Activity);
            WebDriver.FindElement(By.Id("time_entry_hours")).SendKeys(activity.Hours.ToString());
            WebDriver.FindElement(By.Id("time_entry_spent_on")).SendKeys(activity.Date.ToString("MM/DD/YYYY"));
            WebDriver.FindElement(By.Id("time_entry_comments")).SendKeys(activity.Comment);
            var activityDrop = WebDriver.FindElement(By.Id("time_entry_activity_id"));
            var selectActivity = new SelectElement(activityDrop);
            selectActivity.SelectByText(s);
            return true;
        }

        public void Start()
        {
            if (ProjectActivities == null || ProjectActivities.Count == 0)
                throw new Exception("No data to entry");

            OpenProject(IssueNumber);
            foreach(var activity in ProjectActivities)
            {
                LogEntry(activity);     
            }
            
        }
    }
}

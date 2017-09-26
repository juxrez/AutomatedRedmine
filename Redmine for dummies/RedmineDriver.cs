using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine_for_dummies
{
    public  class RedmineDriver : IRedmineDriver
    {
        public string RedmineUrl => "https:\\dev.unosquare.com";
        public IWebDriver WebDriver = new ChromeDriver();
        public string  Username { get; set; }
        public string Password { get; set; }

        public RedmineDriver(string username, string password)
        {
            WebDriver.Url = RedmineUrl;
            Username = username;
            Password = password;
        }

        public bool Login()
        {
            WebDriver.FindElement(By.Name("username")).SendKeys(Username);
            WebDriver.FindElement(By.Name("password")).SendKeys(Password);
            WebDriver.FindElement(By.Name("login")).Click();
            if(string.Equals(WebDriver.PageSource, "https://dev.unosquare.com/redmine/"))
            {
                return true; 
            }

            return false;
        }

        public void OpenProject()
        {
            
        }
        public void Close()
        {
            WebDriver.Quit();
        }
    }
}

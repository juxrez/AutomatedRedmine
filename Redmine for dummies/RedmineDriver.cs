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
        public IWebDriver WebDriver => new ChromeDriver() { Url = RedmineUrl };

        public RedmineDriver()
        {
        }

        public void Login(string username, string password)
        {
            WebDriver.FindElement(By.Name("username")).SendKeys(username);
            WebDriver.FindElement(By.Name("password")).SendKeys(password);
            WebDriver.FindElement(By.Name("login")).Click();
        }

    }
}

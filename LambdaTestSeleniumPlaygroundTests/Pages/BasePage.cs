using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        public string Url => Driver.Url;

        public BasePage(IWebDriver? driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}

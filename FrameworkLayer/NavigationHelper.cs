using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class NavigationHelper
    {
        private IWebDriver driver;
        public NavigationHelper(IWebDriver driver) 
        {
            this.driver = driver;
        }
        public void NavigatetoUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public string FetchPageUrl()
        {
            return driver.Url;
        }
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
    }
}

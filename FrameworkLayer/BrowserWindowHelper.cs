using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class BrowserWindowHelper
    {
        private readonly IWebDriver driver;

        public BrowserWindowHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void FullScreen()
        {
            driver.Manage().Window.FullScreen();
        }
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }
        public void Close()
        {
            driver.Close();
        }
    }
}

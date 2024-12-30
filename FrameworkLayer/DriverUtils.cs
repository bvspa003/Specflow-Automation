/*using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    //SSL Certifcate - capabilities
    //Headless
    //Inprivate
    public class DriverUtils
    {
        IWebDriver driver;
        public DriverUtils(IWebDriver driver)
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
        public void Incognito()
        {
            
        }

        //Actions methods
        public IWebElement LocateElement(By element)
        {
            return driver.FindElement(element);
        }
        public IList<IWebElement> LocateElements(By element)
        {
            return driver.FindElements(element);
        }
        public void TakeScreenshot(string filename)
        {
            var directory = Directory.Exists($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//ErrorSS");
            if (!directory)
            {
                Directory.CreateDirectory($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//ErrorSS");
            }
            string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//ErrorSS//{filename}.jpg";
            driver.TakeScreenshot().SaveAsFile(path);
        }
        public string TakeandFetchScreenshotPath(string filename)
        {
            try
            {
                var directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ErrorSS");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string path = Path.Combine(directoryPath, $"{filename}.jpg");
                driver.TakeScreenshot().SaveAsFile(path);
                //why it is commented
                //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Jpeg);
                return path;
            }
            catch (Exception ex)
            {
                //Log.Error($"Failed to take screenshot: {ex.Message}");
                return null;
            }
        }

        //create Elements-> drop, checkbox, multiiselect
        public void SelectOption(string option)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));
            select.SelectByValue(option);
            Thread.Sleep(1000);
        }
        public void Close()
        {
            driver.Close();
        }

    }
}
*/
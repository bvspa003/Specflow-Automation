using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class ScreenshotHelper
    {
        private IWebDriver driver;

        public ScreenshotHelper(IWebDriver driver)
        {

            this.driver = driver;
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
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
                return null;
            }
        }
    }
}

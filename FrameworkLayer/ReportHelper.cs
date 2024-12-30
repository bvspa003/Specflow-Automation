using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class ReportHelper
    {
        public static ExtentReports extent;
        public static ExtentTest featureName;
        public static ExtentTest scenario;

        public static void InitializeReport()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var directoryPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//Reports";
            //do not use hardcoded file path
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var reportPath = Path.Combine(directoryPath,$"Report_{timestamp}.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
    }
}

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class BrowserOptions
    {
        public ChromeOptions GetChromeOptions(bool headless = false, bool incognito = false, bool acceptInsecureCerts = false)
        {
            var options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless");
            }

            if (incognito)
            {
                options.AddArgument("--incognito");
            }

            if (acceptInsecureCerts)
            {
                options.AcceptInsecureCertificates = true;
            }

            return options;
        }
        public EdgeOptions GetEdgeOptions(bool headless = false, bool incognito = false, bool acceptInsecureCerts = false)
        {
            var options = new EdgeOptions();

            if (headless)
            {
                options.AddArgument("headless");
            }

            if (incognito)
            {
                options.AddArgument("inprivate");
            }

            if (acceptInsecureCerts)
            {
                options.AcceptInsecureCertificates = true;
            }

            return options;
        }
    }
}

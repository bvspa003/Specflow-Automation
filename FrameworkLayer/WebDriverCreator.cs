using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
namespace AutomationFrameworkUtilities
{
    public sealed class WebDriverCreator
    {
        private static IWebDriver? _driver;
        private static readonly WebDriverCreator instance = new WebDriverCreator();
        //private static readonly Lazy<WebDriverCreator> instance = new Lazy<WebDriverCreator>(() => new WebDriverCreator);

        private WebDriverCreator() { }
        public static WebDriverCreator Instance { get { return instance; } }

        public IWebDriver GetDriver(string name)
        {

            if (_driver == null)
            {
                switch (name)
                {
                    case "chrome": _driver = new ChromeDriver(); break;
                    case "edge": _driver = new EdgeDriver(); break;
                    default: _driver = new ChromeDriver(); break;
                }

            }
            return _driver;
        }
        public IWebDriver GetDriver(string name, bool headless, bool incognito, bool acceptInsecureCerts)
        {
            if (_driver == null)
            {
                BrowserOptions browserOptions = new BrowserOptions();
                switch (name.ToLower())
                {
                    case "chrome":
                        _driver = new ChromeDriver(browserOptions.GetChromeOptions(headless, incognito, acceptInsecureCerts));
                        break;
                    case "edge":
                        _driver = new EdgeDriver(browserOptions.GetEdgeOptions(headless, incognito, acceptInsecureCerts));
                        break;
                    default:
                        _driver = new ChromeDriver(browserOptions.GetChromeOptions(headless, incognito, acceptInsecureCerts));
                        break;
                }
            }
            return _driver;
        }
        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}

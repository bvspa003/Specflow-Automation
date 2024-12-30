using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace AutomationFrameworkUtilities
{
    public class Waits
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Waits(IWebDriver driver, TimeSpan timeout)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, timeout);
        }

        public IWebElement WaitForElementToBeVisible(Locator locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(ConvertToBy(locator)));
        }

        public IWebElement WaitForElementToBeClickable(Locator locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(ConvertToBy(locator)));
        }

        public bool WaitForElementToBeInvisible(Locator locator)
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ConvertToBy(locator)));
        }

        public bool WaitForTextToBePresentInElement(Locator locator, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(ConvertToBy(locator), text));
        }

        private By ConvertToBy(Locator locator)
        {
            return locator.LocatorType switch
            {
                "Id" => By.Id(locator.LocatorValue),
                "Name" => By.Name(locator.LocatorValue),
                "ClassName" => By.ClassName(locator.LocatorValue),
                "CssSelector" => By.CssSelector(locator.LocatorValue),
                "XPath" => By.XPath(locator.LocatorValue),
                _ => throw new NotSupportedException($"Locator type '{locator.LocatorType}' is not supported."),
            };
        }
    }
}

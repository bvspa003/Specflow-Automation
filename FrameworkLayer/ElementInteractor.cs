using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace AutomationFrameworkUtilities
{
    public class ElementInteractor
    {
        private IWebDriver driver;
        private Actions actions;

        public ElementInteractor(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
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
        public IWebElement LocateElement(Locator element)
        {
            return driver.FindElement(ConvertToBy(element));
        }

        public IList<IWebElement> LocateElements(Locator element)
        {
            return driver.FindElements(ConvertToBy(element));
        }

        public void SelectOption(Locator element,string option)
        {
            //SelectElement select = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));
            SelectElement select = new SelectElement(LocateElement(element));
            select.SelectByValue(option);
            //Thread.Sleep(1000);
        }

        public bool IsElementVisible(Locator element)
        {
            return LocateElement(element).Displayed;
        }
        //Actions
        public void ClickElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.Click(webElement).Perform();
        }

        public void DoubleClickElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.DoubleClick(webElement).Perform();
        }

        public void RightClickElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.ContextClick(webElement).Perform();
        }

        public void DragAndDropElement(Locator sourceElement, Locator targetElement)
        {
            var source = LocateElement(sourceElement);
            var target = LocateElement(targetElement);
            actions.DragAndDrop(source, target).Perform();
        }

        public void HoverOverElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.MoveToElement(webElement).Perform();
        }

        public void ClickAndHoldElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.ClickAndHold(webElement).Perform();
        }

        public void ReleaseElement(Locator element)
        {
            var webElement = LocateElement(element);
            actions.Release(webElement).Perform();
        }

        public void SendKeysToElement(Locator element, string keys)
        {
            var webElement = LocateElement(element);
            if (!string.IsNullOrEmpty(keys))
            {
                actions.SendKeys(webElement, keys).Perform();
            }
        }
        public string GetElementText(Locator locator)
        {
            return LocateElement(locator).Text;
        }

        public IList<string> GetElementsText(Locator locator)
        {
            var elements = LocateElements(locator);
            var texts = new List<string>();
            foreach (var element in elements)
            {
                texts.Add(element.Text);
            }
            return texts;
            
        }

        public IWebElement LocateChildElement(IWebElement parentElement, Locator childLocator)
        {
            return parentElement.FindElement(ConvertToBy(childLocator));
        }

        public IList<IWebElement> LocateChildElements(IWebElement parentElement, Locator childLocator)
        {
            return parentElement.FindElements(ConvertToBy(childLocator));
        }

    }
}

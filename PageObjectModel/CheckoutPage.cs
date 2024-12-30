using AutomationFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    public class CheckoutPage
    {
        ElementInteractor elementInteractor;
        Waits waits;
        public CheckoutPage(ElementInteractor elementInteractor, Waits waits)
        {
            this.elementInteractor = elementInteractor;
            this.waits = waits;
        }
        public void EnterFirstName(string firstName)
        {
            var locator = Locator.Name("firstName");
            elementInteractor.SendKeysToElement(locator, firstName);
        }

        public void EnterLastName(string lastName)
        {
            var locator = Locator.Name("lastName");
            elementInteractor.SendKeysToElement(locator, lastName);
        }

        public void EnterZipCode(string zipCode)
        {
            var locator = Locator.Name("postalCode");
            elementInteractor.SendKeysToElement(locator, zipCode);
        }

        public void ClickContinue()
        {
            var locator = Locator.Name("continue");
            elementInteractor.ClickElement(locator);
        }

        public string FetchError()
        {
            var locator = Locator.XPath("//h3[@data-test='error']");
            waits.WaitForElementToBeVisible(locator);
            return elementInteractor.GetElementText(locator);
        }

        public void ClickFinish()
        {
            var locator = Locator.Id("finish");
            elementInteractor.ClickElement(locator);
        }

        public string FetchSuccessMessage()
        {
            var locator = Locator.XPath("//h2[@class='complete-header']");
            return elementInteractor.GetElementText(locator);
        }


        /*DriverUtils driverUtils;
        WebDriverWait wait;
        public CheckoutPage(IWebDriver driver)
        {
            driverUtils = new DriverUtils(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }
        public void FirstName(string fname)
        {
            driverUtils.LocateElement(By.Name("firstName")).SendKeys(fname);
        }
        public void LastName(string lname)
        {
            driverUtils.LocateElement(By.Name("lastName")).SendKeys(lname);
        }
        public void Zip(string zip)
        {
            driverUtils.LocateElement(By.Name("postalCode")).SendKeys(zip);
        }
        public void ClickContinue()
        {
            driverUtils.LocateElement(By.Name("continue")).Click();
        }
        public string FetchError()
        {
            //By element = By.CssSelector(".error-message-container error");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h3[@data-test='error']")));
            return driverUtils.LocateElement(By.XPath("//h3[@data-test='error']")).Text;
        }
        public void ClickFinish()
        {
            driverUtils.LocateElement(By.Id("finish")).Click();
        }
        public string FetchSuccessMessage()
        {
            return driverUtils.LocateElement(By.XPath("//h2[@class='complete-header']")).Text;
        }*/
    }
}

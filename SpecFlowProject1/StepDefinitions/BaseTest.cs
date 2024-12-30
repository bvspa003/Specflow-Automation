/*using AutomationFrameworkUtilities;
using OpenQA.Selenium;
using PageObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestSuite.StepDefinitions
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected DriverUtils driverUtils;
        protected BrowserOptions browserOptions;
        protected BrowserWindowHelper browserWindowHelper;
        protected ElementInteractor elementInteractor;
        protected NavigationHelper navigationHelper;
        protected ScreenshotHelper screenshotHelper;
        protected LoginPage loginPage;
        protected ProductPage productPage;
        protected CartPage cartPage;
        protected CheckoutPage checkoutPage;
        protected ScenarioContext scenarioContext;
        protected TestSettings settings;

        public BaseTest(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = scenarioContext.Get<IWebDriver>("WebDriver");
            driverUtils = scenarioContext.Get<DriverUtils>("DriverUtils");
            settings = scenarioContext.Get<TestSettings>("Settings");
            browserOptions = new BrowserOptions();
            browserWindowHelper = new BrowserWindowHelper(driver);
            elementInteractor = new ElementInteractor(driver);
            navigationHelper = new NavigationHelper(driver);
            screenshotHelper = new ScreenshotHelper(driver);
*//*            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);*//*
        }
    }
}
*/
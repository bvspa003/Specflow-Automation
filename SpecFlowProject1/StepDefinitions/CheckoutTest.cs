/*using AutomationFrameworkUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class CheckoutTest:BaseTest
    {
        public CheckoutTest(ScenarioContext scenarioContext) : base(scenarioContext) { }
        *//*private IWebDriver driver;
        private WebDriverUtil WdriverUtil;
        DriverUtils driverUtils;
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;
        CheckoutPage checkoutPage;
        ScenarioContext scenarioContext;
        TSettings settings;*/

        /*public CheckoutTest(WebDriverUtil webDriverUtil, ScenarioContext scenarioContext)
        {
            WdriverUtil = webDriverUtil;
            this.scenarioContext = scenarioContext;
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"logs\\{scenarioContext.ScenarioInfo.Tags.First()}.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        [BeforeScenario]
        public void Setup()
        {
            settings = ConfigReader.GetConfig("C:\\Training Session files\\Functional Testing new\\26-06\\SpecFlowProject1\\SpecFlowProject1\\Settings.json");
            //WdriverUtil = new WebDriverUtil();
            //driver = WdriverUtil.GetDriver("chrome");
            driver = WdriverUtil.GetDriver(settings.Browser);
            driverUtils = new DriverUtils(driver);
            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }
        [AfterScenario]
        public void Teardown()
        {
            Thread.Sleep(1000);
            Log.Information($"Ending scenario: {scenarioContext.ScenarioInfo.Title}");
            WdriverUtil.QuitDriver();
            //driverUtils.Close();
        }*//*

        [Given(@"I'm logged in, added products to cart, went to cart and clicked Checkout")]
        public void GivenImLoggedInAddedProductsToCartWentToCartAndClickedCheckout()
        {
            driverUtils.Maximize();
            //driverUtils.NavigatetoUrl("https://www.saucedemo.com/");
            driverUtils.NavigatetoUrl(settings.Url);
            //Fetch data from source 
            loginPage.Username("standard_user");
            loginPage.Password("secret_sauce");
            loginPage.ClickLogin();
            productPage.AddAllItemsToCart();
            productPage.GoToCart();
            cartPage.Checkout();
            Log.Information($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");
        }
        //MissingDetailTests
        [When(@"I enter ""(.*)"" as the First Name")]
        public void WhenIEnterAsTheFirstName(string p0)
        {
            checkoutPage.FirstName(p0);
        }

        [When(@"I enter ""(.*)"" as the Last Name")]
        public void WhenIEnterAsTheLastName(string p0)
        {
            checkoutPage.LastName(p0);
        }

        [When(@"I enter ""(.*)"" as the Zip/Postal Code")]
        public void WhenIEnterAsTheZipPostalCode(string p0)
        {
            checkoutPage.Zip(p0);
        }

        [When(@"I click Continue")]
        public void WhenIClickContinue()
        {
            checkoutPage.ClickContinue();
        }

        [Then(@"I should get the ""(.*)""")]
        public void ThenIShouldGetThe(string p0)
        {
            driverUtils.TakeScreenshot(p0);
            Assert.IsTrue(checkoutPage.FetchError().Contains(p0));
        }
        //Normaltest
        [When(@"I click Finish")]
        public void WhenIClickFinish()
        {
            checkoutPage.ClickFinish();
        }

        [Then(@"I should get rerouted to Checkout Overview")]
        public void ThenIShouldGetReroutedToCheckoutOverview()
        {
            Assert.IsTrue(driverUtils.FetchPageUrl().Contains("checkout-step-two.html"));
        }

        [Then(@"I get rerouted to Checkout Complete")]
        public void ThenIGetReroutedToCheckoutComplete()
        {
            driverUtils.TakeScreenshot("CheckoutComplete");
            Assert.IsTrue(driverUtils.FetchPageUrl().Contains("checkout-complete.html"));
        }

        [Then(@"I get ""(.*)"" as a part of the success message")]
        public void ThenIGetAsAPartOfTheSuccessMessage(string p0)
        {
            Assert.IsTrue(checkoutPage.FetchSuccessMessage().Contains(p0));
        }
    }
}
*/
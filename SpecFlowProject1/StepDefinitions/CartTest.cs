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
    public class CartTest:BaseTest
    {
        public CartTest(ScenarioContext scenarioContext) : base(scenarioContext) { }
        *//*private IWebDriver driver;
        private WebDriverUtil WdriverUtil;
        DriverUtils driverUtils;
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;
        ScenarioContext scenarioContext;
        TSettings settings;

        public CartTest(WebDriverUtil webDriverUtil, ScenarioContext scenarioContext)
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
        }
        [AfterScenario]
        public void Teardown()
        {
            Thread.Sleep(1000);
            Log.Information($"Ending scenario: {scenarioContext.ScenarioInfo.Title}");
            WdriverUtil.QuitDriver();
            //driverUtils.Close();
        }*//*
        [Given(@"I add all items to the cart")]
        public void GivenIAddAllItemsToTheCart()
        {
            driverUtils.Maximize();
            //driverUtils.NavigatetoUrl("https://www.saucedemo.com/");
            driverUtils.NavigatetoUrl(settings.Url);
            loginPage.Username("standard_user");
            loginPage.Password("secret_sauce");
            loginPage.ClickLogin();
            productPage.AddAllItemsToCart();
            Log.Information($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");
        }
        [Given(@"I go to cart")]
        public void GivenIGoToCart()
        {
            productPage.GoToCart();
        }
        [When(@"I remove ""(.*)"", ""(.*)"" two items from the cart")]
        public void WhenIRemoveTwoItemsFromTheCart(string p0, string p1)
        {
            cartPage.RemoveProductsFromCart(p0,p1);
        }

        [Then(@"the items should be removed")]
        public void ThenTheItemsShouldBeRemoved()
        {
            driverUtils.TakeScreenshot("Removing2incart");
            Assert.IsTrue(cartPage.GetCartCount() == 4);
        }

    }
}
*/
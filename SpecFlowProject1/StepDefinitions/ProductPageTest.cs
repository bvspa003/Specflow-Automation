/*using AutomationFrameworkUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    public class ProductPageTest:BaseTest
    {
        public ProductPageTest(ScenarioContext scenarioContext) : base(scenarioContext) { }
        *//*private IWebDriver driver;
        private WebDriverUtil WdriverUtil;
        DriverUtils driverUtils;
        LoginPage loginPage;
        ProductPage productPage;
        ScenarioContext scenarioContext;
        TSettings settings;

        public ProductPageTest(WebDriverUtil webDriverUtil, ScenarioContext scenarioContext)
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
            
        }
        [AfterScenario]
        public void Teardown()
        {
            Thread.Sleep(1000);
            Log.Information($"Ending scenario: {scenarioContext.ScenarioInfo.Title}");
            WdriverUtil.QuitDriver();
            //driverUtils.Close();
        }*//*
        [Given(@"I'm logged in to SauceDemo")]
        public void GivenImLoggedInToSauceDemo()
        {
            driverUtils.Maximize();
            //driverUtils.NavigatetoUrl("https://www.saucedemo.com/");
            driverUtils.NavigatetoUrl(settings.Url);
            loginPage.Username("standard_user");
            loginPage.Password("secret_sauce");
            loginPage.ClickLogin();
            Log.Information($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");

            //Performed in BeforeScenario
        }
        //Add Each product
        [When(@"I add the product ""(.*)"" to the cart")]
        public void WhenIAddTheProductToTheCart(string p0)
        {
            productPage.AddProductToCart(p0);
        }

        [Then(@"the product ""(.*)"" should be in the cart")]
        public void ThenTheProductShouldBeInTheCart(string p0)
        {
            Assert.IsTrue(productPage.GetCartCount()== 1);
        }
        //Remove each
        [Given(@"I have added the product ""(.*)"" to the cart")]
        public void GivenIHaveAddedTheProductToTheCart(string p0)
        {
            productPage.AddProductToCart(p0);
        }
        [When(@"I remove the product ""(.*)"" from the cart")]
        public void WhenIRemoveTheProductFromTheCart(string p0)
        {
            productPage.RemoveProductFromCart(p0);
        }

        [Then(@"the product ""(.*)"" should not be in the cart")]
        public void ThenTheProductShouldNotBeInTheCart(string p0)
        {
            Assert.IsTrue(productPage.GetCartCount() == 0);
        }
        //Add all
        [When(@"I add all the products to the cart")]
        public void WhenIAddAllTheProductsToTheCart()
        {
             productPage.AddAllItemsToCart();
        }

        [Then(@"the cart badge should display ""(.*)""")]
        public void ThenTheCartBadgeShouldDisplay(string p0)
        {
            Assert.IsTrue(productPage.GetCartCount() == int.Parse(p0));
        }
        //View Product
        [When(@"I view the details of product ""(.*)""")]
        public void WhenIViewTheDetailsOfProduct(string p0)
        {
            productPage.ViewProductDetails(p0);
        }

        [Then(@"the product ""(.*)"" details should be displayed")]
        public void ThenTheProductDetailsShouldBeDisplayed(string p0)
        {
            Assert.IsTrue(driverUtils.FetchPageUrl().Contains("inventory-item.html"));
        }

        [Then(@"the product name should be ""(.*)""")]
        public void ThenTheProductNameShouldBe(string p0)
        {
            Assert.IsTrue(productPage.FetchProductName()==p0);
        }
        //SortName
        [When(@"I select the sort products by name \(A-Z\) option")]
        public void WhenISelectTheSortProductsByNameA_ZOption()
        {
            productPage.Sortby("az");
        }

        [Then(@"the inventory must be sorted by name in ascending order")]
        public void ThenTheInventoryMustBeSortedByNameInAscendingOrder()
        {
            Assert.IsTrue(productPage.IsAscending(productPage.InventoryNames()));
        }

        //SortNameDESC
        [When(@"I select the sort products by name \(Z-A\) option")]
        public void WhenISelectTheSortProductsByNameZ_AOption()
        {
            productPage.Sortby("za");
        }

        [Then(@"the inventory must be sorted by name in descending order")]
        public void ThenTheInventoryMustBeSortedByNameInDescendingOrder()
        {
            Assert.IsTrue(productPage.IsDescending(productPage.InventoryNames()));
        }

        //SortPrice
        [When(@"I select the sort products by price \(low-high\) option")]
        public void WhenISelectTheSortProductsByPriceLow_HighOption()
        {
            productPage.Sortby("lohi");
        }

        [Then(@"the inventory must be sorted by price in ascending order")]
        public void ThenTheInventoryMustBeSortedByPriceInAscendingOrder()
        {
            Assert.IsTrue(productPage.IsAscending(productPage.InventoryPrices()));
        }
        //SortPriceDESC
        [When(@"I select the sort products by price \(high-low\) option")]
        public void WhenISelectTheSortProductsByPriceHigh_LowOption()
        {
            productPage.Sortby("hilo");
        }

        [Then(@"the inventory must be sorted by price in descending order")]
        public void ThenTheInventoryMustBeSortedByPriceInDescendingOrder()
        {
            Assert.IsTrue(productPage.IsDescending(productPage.InventoryPrices()));
        }
    }
}
*/
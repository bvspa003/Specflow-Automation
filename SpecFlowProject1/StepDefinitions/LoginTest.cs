/*using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutomationFrameworkUtilities;
using PageObjectModel;
using Serilog;
using System.Reflection;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class LoginTest:BaseTest
    {
        public LoginTest(ScenarioContext scenarioContext) : base(scenarioContext) { }
        *//*private IWebDriver driver;
        private WebDriverUtil WdriverUtil;
        DriverUtils driverUtils;
        LoginPage loginPage;
        ScenarioContext scenarioContext;
        TSettings settings;*/


        /*public LoginTest(WebDriverUtil webDriverUtil, ScenarioContext scenarioContext)
        {
            WdriverUtil = webDriverUtil;
            this.scenarioContext = scenarioContext;
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"logs\\{scenarioContext.ScenarioInfo.Tags.First()}.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        [BeforeScenario]
        public void Setup()
        {
            settings = ConfigReader.GetConfig("C:\\Training Session files\\Functional Testing new\\26-06\\SpecFlowProject1\\SpecFlowProject1\\Settings.json");
            //WdriverUtil = new WebDriverUtil();
            //driver = WdriverUtil.GetDriver("chrome");
            driver= WdriverUtil.GetDriver(settings.Browser);
            driverUtils = new DriverUtils(driver);
            loginPage = new LoginPage(driver);
        }
        [AfterScenario]
        public void Teardown()
        {
            Thread.Sleep(1000);
            Log.Information($"Ending scenario: {scenarioContext.ScenarioInfo.Title}");
            WdriverUtil.QuitDriver();
            //driverUtils.Close();
        }*//*
        //[Test]
        //public void Test()
        //{
        //    Assert.Pass();
        //}
        //Given is same for all, so it can be written once
        [Given(@"I'm on the Saucedemo login page")]
        public void GivenImOnTheSaucedemoLoginPage()
        {
            Log.Information($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");
            driverUtils.Maximize();
            //driverUtils.NavigatetoUrl("https://www.saucedemo.com/");
            driverUtils.NavigatetoUrl(settings.Url);
            Log.Information("Navigating to Saucedemo login page");
            Assert.IsTrue(driverUtils.FetchPageUrl() == "https://www.saucedemo.com/");
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            Log.Information("Entering valid credentials");
            loginPage.Username("standard_user");
            loginPage.Password("secret_sauce");
            //Assert.Pass();
        }

        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            Log.Information("Entering invalid credentials");
            loginPage.Username("invalid_user");
            loginPage.Password("invalid_sauce");
            //Assert.Pass();
        }
        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            Log.Information("Clicking login button");
            loginPage.ClickLogin();
            //Assert.Pass();
        }
        [When(@"I enter the credentials of a locked out user")]
        public void WhenIEnterTheCredentialsOfALockedOutUser()
        {
            Log.Information("Entering locked user credentials");
            loginPage.Username("locked_out_user");
            loginPage.Password("secret_sauce");
        }
        [When(@"I leave the username and password fields empty")]
        public void WhenILeaveTheUsernameAndPasswordFieldsEmpty()
        {
            //We don't need to pass anything
            Log.Information("Entering empty credentials");
        }
        [When(@"I leave the username field empty")]
        public void WhenILeaveTheUsernameFieldEmpty()
        {
            Log.Information("Entering the password only");
            loginPage.Password("thepassword");
        }
        [When(@"I leave the password field empty")]
        public void WhenILeaveThePasswordFieldEmpty()
        {
            Log.Information("Entering the username only");
            loginPage.Username("standard_user");
        }
        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnterOtherUnamesAndpasswords(string p0, string p1)
        {
            Log.Information($"Entering the {p0} as username, {p1} as the password");
            loginPage.Username(p0);
            loginPage.Password(p1);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string p0)
        {
            Log.Information($"Verified Successful Login and {p0} Inventory is displayed");
            Thread.Sleep(2000);
            driverUtils.TakeScreenshot("success");
            Assert.IsTrue(driverUtils.FetchPageUrl().Contains("/inventory.html"));
        }
        [Then(@"I should be rerouted to products page")]
        public void ThenIShouldBeReroutedToProductsPage()
        {
            Log.Information("Verifying Successful Login");
            Thread.Sleep(3000);
            driverUtils.TakeScreenshot("success");
            Assert.IsTrue(driverUtils.FetchPageUrl().Contains("/inventory.html"));
        }
        [Then(@"I should see an error message indicating that the credentials are invalid")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheCredentialsAreInvalid()
        {
            Log.Error("Please Check the credentials");
            Log.Information("Verifying error message for invalid credentials");
            driverUtils.TakeScreenshot("uname_pwd_mismatch");
            Assert.IsTrue(loginPage.FetchErrorMessage().Contains("Username and password do not match any user"));
        }
        [Then(@"I should see an error message indicating that the user is locked out")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheUserIsLockedOut()
        {
            Log.Fatal("User Locked! Contact Admin");
            Log.Information("Verifying error message for locked user credentials");
            driverUtils.TakeScreenshot("lockeduser");
            Assert.IsTrue(loginPage.FetchErrorMessage().Contains("user has been locked out."));
        }
        [Then(@"I should see an error message indicating that both fields are required")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatBothFieldsAreRequired()
        {
            Log.Warning("Missing Credentials");
            Log.Information("Verifying error message for empty credentials");
            driverUtils.TakeScreenshot("uname_pwd_missing");
            Assert.IsTrue(loginPage.FetchErrorMessage().Contains("is required"));
        }
        [Then(@"I should see an error message indicating that the username field is required")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheUsernameFieldIsRequired()
        {
            Log.Error("Username Required");
            Log.Information("Verifying error message for required username");
            driverUtils.TakeScreenshot("uname_missing"); 
            Assert.IsTrue(loginPage.FetchErrorMessage().Contains("Username is required"));
        }
        [Then(@"I should see an error message indicating that the password field is required")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatThePasswordFieldIsRequired()
        {
            Log.Error("Password Required");
            Log.Information("Verifying error message for required password");
            driverUtils.TakeScreenshot("pwd_misssing");
            Assert.IsTrue(loginPage.FetchErrorMessage().Contains("Password is required"));
        }
    }
}
*/
using AutomationFrameworkUtilities;
using NUnit.Framework;
using PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        #region DependecyInjectionSetup
        LoginPage _loginPage;
        TestSettings _testSettings;
        ScenarioContext _scenarioContext;
        NavigationHelper _navigationHelper;
        BrowserWindowHelper _browserWindowHelper;
        ElementInteractor _elementInteractor;
        Waits _waits;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _testSettings = _scenarioContext.Get<TestSettings>("Settings");
            _elementInteractor = _scenarioContext.Get<ElementInteractor>("ElementInteractor");
            _waits = _scenarioContext.Get<Waits>("Waits");
            _loginPage = new LoginPage(_elementInteractor,_waits);
            _navigationHelper = _scenarioContext.Get<NavigationHelper>("NavigationHelper");
            _browserWindowHelper = _scenarioContext.Get<BrowserWindowHelper>("BrowserWindowHelper");
        }
        #endregion

        [Given(@"the Saucedemo login page is displayed")]
        public void GivenTheSaucedemoLoginPageIsDisplayed()
        {
            _browserWindowHelper.Maximize();
            _navigationHelper.NavigatetoUrl(_testSettings.Url);
        }

        [When(@"valid credentials are entered")]
        public void WhenValidCredentialsAreEntered()
        {
            _loginPage.EnterUsername(_testSettings.Username);
            _loginPage.EnterPassword(_testSettings.Password);
        }

        [When(@"the login button is clicked")]
        public void WhenTheLoginButtonIsClicked()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"the user should be rerouted to the products page")]
        public void ThenTheUserShouldBeReroutedToTheProductsPage()
        {
            string currentUrl =_navigationHelper.FetchPageUrl();
            if (!currentUrl.Contains("/inventory.html"))
            {
                throw new Exception("User is not on the products page.");
            }
            else
            {
                Assert.IsTrue(currentUrl.Contains("/inventory.html"));
            }

        }

        [When(@"""([^""]*)"" and ""([^""]*)"" are entered")]
        public void WhenAndAreEntered(string p0, string p1)
        {
            _loginPage.EnterUsername(p0);
            _loginPage.EnterPassword(p1);
        }

        [Then(@"an error message indicating that ""([^""]*)"" should be displayed")]
        public void ThenAnErrorMessageIndicatingThatShouldBeDisplayed(string p0)
        {
            var isErrorMessageDisplayed = _loginPage.IsErrorMessageDisplayed(p0);
            if (!isErrorMessageDisplayed)
            {
                throw new Exception($"Expected error message '{p0}' was not displayed.");
            }
        }

        [When(@"the credentials of a locked out user are entered")]
        public void WhenTheCredentialsOfALockedOutUserAreEntered()
        {
            _loginPage.EnterUsername("locked_out_user");
            _loginPage.EnterPassword("secret_sauce");
        }

        [Then(@"an error message indicating that the user is locked out should be displayed")]
        public void ThenAnErrorMessageIndicatingThatTheUserIsLockedOutShouldBeDisplayed()
        {
            var expectedMessage = "Sorry, this user has been locked out.";
            var isErrorMessageDisplayed = _loginPage.IsErrorMessageDisplayed(expectedMessage);
            if (!isErrorMessageDisplayed)
            {
                throw new Exception("Expected error message for locked out user was not displayed.");
            }
        }

        [Then(@"""([^""]*)"" should be displayed")]
        public void ThenShouldBeDisplayed(string p0)
        {
            string currentUrl = _navigationHelper.FetchPageUrl();
            if (!currentUrl.Contains("/inventory.html"))
            {
                throw new Exception("User is not on the products page.");
            }
            else
            {
                Assert.IsTrue(currentUrl.Contains("/inventory.html"));
            }
        }
    }
}

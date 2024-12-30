using AutomationFrameworkUtilities;
using NUnit.Framework;
using PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        #region DependencyInjectionSetup
        ScenarioContext _scenarioContext;
        LoginStepDefinitions _loginStepDefinitions;
        ProductStepDefinitions _productStepDefinitions;
        CartPage _cartPage;
        CheckoutPage _checkoutPage;
        NavigationHelper _navigationHelper;
        ElementInteractor _elementInteractor;
        Waits _waits;

        public CheckoutStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginStepDefinitions = new LoginStepDefinitions(scenarioContext);
            _productStepDefinitions = new ProductStepDefinitions(scenarioContext);
            _elementInteractor = _scenarioContext.Get<ElementInteractor>("ElementInteractor");
            _waits = _scenarioContext.Get<Waits>("Waits");
            _navigationHelper = _scenarioContext.Get<NavigationHelper>("NavigationHelper");
            _cartPage = new CartPage(_elementInteractor);
            _checkoutPage = new CheckoutPage(_elementInteractor, _waits);
        }
        #endregion

        [Given(@"the user is logged in")]
        public void GivenTheUserIsLoggedIn()
        {
            _loginStepDefinitions.GivenTheSaucedemoLoginPageIsDisplayed();
            _loginStepDefinitions.WhenValidCredentialsAreEntered();
            _loginStepDefinitions.WhenTheLoginButtonIsClicked();
        }

        [Given(@"products are added to the cart")]
        public void GivenProductsAreAddedToTheCart()
        {
            _productStepDefinitions.WhenAllTheProductsAreAddedToTheCart();
        }

        [Given(@"Checkout is clicked")]
        public void GivenCheckoutIsClicked()
        {
            _cartPage.Checkout();
        }

        [When(@"""([^""]*)"" is entered as the First Name")]
        public void WhenIsEnteredAsTheFirstName(string p0)
        {
            _checkoutPage.EnterFirstName(p0);
        }

        [When(@"""([^""]*)"" is entered as the Last Name")]
        public void WhenIsEnteredAsTheLastName(string p0)
        {
            _checkoutPage.EnterLastName(p0);
        }

        [When(@"""([^""]*)"" is entered as the Zip/Postal Code")]
        public void WhenIsEnteredAsTheZipPostalCode(string p0)
        {
            _checkoutPage.EnterZipCode(p0);
        }

        [When(@"Continue is clicked")]
        public void WhenContinueIsClicked()
        {
            _checkoutPage.ClickContinue();
        }
        [Then(@"the ""([^""]*)"" should be displayed")]
        public void ThenTheShouldBeDisplayed(string p0)
        {
            Assert.IsTrue(_checkoutPage.FetchError().Contains(p0));
        }

        [Then(@"the user should be rerouted to Checkout Overview")]
        public void ThenTheUserShouldBeReroutedToCheckoutOverview()
        {
            Assert.IsTrue(_navigationHelper.FetchPageUrl().Contains("checkout"));
        }

        [When(@"Finish is clicked")]
        public void WhenFinishIsClicked()
        {
            _checkoutPage.ClickFinish();
        }

        [Then(@"the user should be rerouted to Checkout Complete")]
        public void ThenTheUserShouldBeReroutedToCheckoutComplete()
        {
            Assert.IsTrue(_navigationHelper.FetchPageUrl().Contains("checkout-complete"));
        }

        [Then(@"""([^""]*)"" should be part of the success message")]
        public void ThenShouldBePartOfTheSuccessMessage(string p0)
        {
            Assert.IsTrue(_checkoutPage.FetchSuccessMessage().Contains(p0));
        }
    }
}

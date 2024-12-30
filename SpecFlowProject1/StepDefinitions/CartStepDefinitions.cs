using AutomationFrameworkUtilities;
using NUnit.Framework;
using PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        #region DependencyInjectionSetup
        ScenarioContext _scenarioContext;
        LoginStepDefinitions _loginStepDefinitions;
        ProductStepDefinitions _productStepDefinitions;
        CartPage _cartPage;
        ProductPage _productPage;
        ElementInteractor _elementInteractor;
        NavigationHelper _navigationHelper;
        Waits _waits;
        public CartStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _elementInteractor = _scenarioContext.Get<ElementInteractor>("ElementInteractor");
            _waits = _scenarioContext.Get<Waits>("Waits");
            _loginStepDefinitions = new LoginStepDefinitions(scenarioContext);
            _productStepDefinitions = new ProductStepDefinitions(scenarioContext);
            _cartPage = new CartPage(_elementInteractor);
            _productPage = new ProductPage(_elementInteractor,_waits);
            _navigationHelper = _scenarioContext.Get<NavigationHelper>("NavigationHelper");
        }
        #endregion

        [Given(@"all items are added to the cart")]
        public void GivenAllItemsAreAddedToTheCart()
        {
            _loginStepDefinitions.GivenTheSaucedemoLoginPageIsDisplayed();
            _loginStepDefinitions.WhenValidCredentialsAreEntered();
            _loginStepDefinitions.WhenTheLoginButtonIsClicked();
            _productStepDefinitions.WhenAllTheProductsAreAddedToTheCart();
        }

        [Given(@"the cart page is navigated to")]
        public void GivenTheCartPageIsNavigatedTo()
        {
            _productPage.GoToCart();
            Assert.IsTrue(_navigationHelper.FetchPageUrl().Contains("cart"));
        }

        [When(@"""([^""]*)"" and ""([^""]*)"" are removed from the cart")]
        public void WhenAndAreRemovedFromTheCart(string p0, string p1)
        {
           _cartPage.RemoveProductsFromCart(p0, p1);
        }

        [Then(@"""([^""]*)"" and ""([^""]*)"" should be removed")]
        public void ThenAndShouldBeRemoved(string p0, string p1)
        {
            Assert.IsFalse(_cartPage.IsProductInCart(p0));
            Assert.IsFalse(_cartPage.IsProductInCart(p1));
        }


    }
}

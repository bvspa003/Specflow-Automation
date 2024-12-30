using AutomationFrameworkUtilities;
using NUnit.Framework;
using PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class ProductStepDefinitions
    {
        #region DependencyInjectionSetup
        ProductPage _productPage;
        ScenarioContext _scenarioContext;
        LoginStepDefinitions _loginStepDefinitions;
        NavigationHelper _navigationHelper;
        public ProductStepDefinitions(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            var elementInteractor = _scenarioContext.Get<ElementInteractor>("ElementInteractor");
            var waits = _scenarioContext.Get<Waits>("Waits");
            _productPage = new ProductPage(elementInteractor, waits);
            _loginStepDefinitions = new LoginStepDefinitions(_scenarioContext);
            _navigationHelper = _scenarioContext.Get<NavigationHelper>("NavigationHelper");
        }
        #endregion

        [Given(@"the user is logged in to SauceDemo")]
        public void GivenTheUserIsLoggedInToSauceDemo()
        {
            _loginStepDefinitions.GivenTheSaucedemoLoginPageIsDisplayed();
            _loginStepDefinitions.WhenValidCredentialsAreEntered();
            _loginStepDefinitions.WhenTheLoginButtonIsClicked();
        }

        [When(@"the product ""([^""]*)"" is added to the cart")]
        public void WhenTheProductIsAddedToTheCart(string p0)
        {
            _productPage.AddProductToCart(p0);
        }

        [Given(@"the product ""([^""]*)"" is added to the cart")]
        public void GivenTheProductIsAddedToTheCart(string p0)
        {
            _productPage.AddProductToCart(p0);
        }

        [When(@"the product ""([^""]*)"" is removed from the cart")]
        public void WhenTheProductIsRemovedFromTheCart(string p0)
        {
            _productPage.RemoveProductFromCart(p0);
        }

        [When(@"the details of product ""([^""]*)"" are viewed")]
        public void WhenTheDetailsOfProductAreViewed(string p0)
        {
            _productPage.ViewProductDetails(p0);
        }

        [When(@"all the products are added to the cart")]
        public void WhenAllTheProductsAreAddedToTheCart()
        {
            _productPage.AddAllItemsToCart();
        }
        [Then(@"the product ""([^""]*)"" should be in the cart")]
        public void ThenTheProductShouldBeInTheCart(string p0)
        {
            _productPage.VerifyAddToCartStatus(p0);
        }

        [Then(@"the cart badge should display ""([^""]*)""")]
        public void ThenTheCartBadgeShouldDisplay(string p0)
        {
            Assert.IsTrue(_productPage.GetCartCount() == int.Parse(p0));
        }

        [Then(@"the product ""([^""]*)"" should not be in the cart")]
        public void ThenTheProductShouldNotBeInTheCart(string p0)
        {
            _productPage.VerifyRemoveFromCartStatus(p0);
        }

        [Then(@"the product ""([^""]*)"" details should be displayed")]
        public void ThenTheProductDetailsShouldBeDisplayed(string p0)
        {
            string currentUrl = _navigationHelper.FetchPageUrl();
            Assert.IsTrue(_navigationHelper.FetchPageUrl().Contains("inventory-item")); 
        }

        [Then(@"the product name should be ""([^""]*)""")]
        public void ThenTheProductNameShouldBe(string p0)
        {
            Assert.IsTrue(_productPage.FetchProductName() == p0);
        }

        [When(@"the sort products by name \(A-Z\) option is selected")]
        public void WhenTheSortProductsByNameA_ZOptionIsSelected()
        {
            _productPage.SortBy("az");
        }

        [Then(@"the inventory should be sorted by name in ascending order")]
        public void ThenTheInventoryShouldBeSortedByNameInAscendingOrder()
        {
            var names = _productPage.InventoryNames();
            Assert.IsTrue(_productPage.IsAscending(names));
        }

        [When(@"the sort products by name \(Z-A\) option is selected")]
        public void WhenTheSortProductsByNameZ_AOptionIsSelected()
        {
            _productPage.SortBy("za");
        }

        [Then(@"the inventory should be sorted by name in descending order")]
        public void ThenTheInventoryShouldBeSortedByNameInDescendingOrder()
        {
            var names = _productPage.InventoryNames();
            Assert.IsTrue(_productPage.IsDescending(names));
        }

        [When(@"the sort products by price \(low-high\) option is selected")]
        public void WhenTheSortProductsByPriceLow_HighOptionIsSelected()
        {
            _productPage.SortBy("lohi");
        }

        [Then(@"the inventory should be sorted by price in ascending order")]
        public void ThenTheInventoryShouldBeSortedByPriceInAscendingOrder()
        {
            var prices = _productPage.InventoryPrices();
            Assert.IsTrue(_productPage.IsAscending(prices));
        }

        [When(@"the sort products by price \(high-low\) option is selected")]
        public void WhenTheSortProductsByPriceHigh_LowOptionIsSelected()
        {
            _productPage.SortBy("hilo");
        }

        [Then(@"the inventory should be sorted by price in descending order")]
        public void ThenTheInventoryShouldBeSortedByPriceInDescendingOrder()
        {
            var prices = _productPage.InventoryPrices();
            Assert.IsTrue(_productPage.IsDescending(prices));
        }
    }
}

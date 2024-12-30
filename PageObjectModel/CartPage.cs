using AutomationFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    public class CartPage
    {
        ElementInteractor elementInteractor;
        public CartPage(ElementInteractor elementInteractor)
        {
            this.elementInteractor = elementInteractor;
        }

        public void RemoveProductsFromCart(string product1, string product2)
        {
            var locator1 = Locator.XPath($"//div[@class='cart_item' and .//div[text()='{product1}']]//button[text()='Remove']");
            var locator2 = Locator.XPath($"//div[@class='cart_item' and .//div[text()='{product2}']]//button[text()='Remove']");
            elementInteractor.ClickElement(locator1);
            elementInteractor.ClickElement(locator2);
        }

        public int GetCartCount()
        {
            var locator = Locator.ClassName("shopping_cart_badge");
            var badgeElement = elementInteractor.LocateElement(locator);
            return int.Parse(badgeElement.Text);
        }

        public void Checkout()
        {
            var locator = Locator.Id("checkout");
            elementInteractor.ClickElement(locator);
        }

        public bool IsProductInCart(string productName)
        {
            var locator = Locator.XPath($"//div[@class='cart_item' and .//div[text()='{productName}']]");
            var removedElement = elementInteractor.LocateElements(locator);
            return removedElement.Count>0;
        }
        /*DriverUtils driverUtils;
        #region Xpath 
        #endregion
        public CartPage(IWebDriver driver)
        {
            driverUtils = new DriverUtils(driver);
        }
        #region Action method
        #endregion
        public void RemoveProductsFromCart(string p0, string p1)
        {
            //xpath =part 1 (string )+part b/c (string) (concatenate)
            //Butto Enum type p0, value0, p1, value1, p2, p3
            //By RemoveButtn(Button button)=> By .Xpath($"//div[@name =button.GetDescription()]")
            //Task  define GetDescription -> define enums key value
            driverUtils.LocateElement(By.XPath($"//div[@class='cart_item' and .//div[text()='{p0}']]//button[text()='Remove']")).Click();
            driverUtils.LocateElement(By.XPath($"//div[@class='cart_item' and .//div[text()='{p1}']]//button[text()='Remove']")).Click();
        }
        public int GetCartCount()
        {
            return int.Parse(driverUtils.LocateElement(By.ClassName("shopping_cart_badge")).Text);
        }
        public void Checkout()
        {
            driverUtils.LocateElement(By.Id("checkout")).Click();
        }*/
    }
}

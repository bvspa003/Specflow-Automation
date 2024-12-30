using AutomationFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    public class ProductPage
    {
        ElementInteractor elementInteractor;
        Waits waits;

        public ProductPage(ElementInteractor elementInteractor, Waits waits)
        {
            this.elementInteractor = elementInteractor;
            this.waits = waits;
        }

        public void AddProductToCart(string productName)
        {
            var locator = Locator.XPath($"//div[@class='inventory_item' and .//div[text()='{productName}']]//button[text()='Add to cart']");
            elementInteractor.ClickElement(locator);
        }

        public void RemoveProductFromCart(string productName)
        {
            var locator = Locator.XPath($"//div[@class='inventory_item' and .//div[text()='{productName}']]//button[text()='Remove']");
            elementInteractor.ClickElement(locator);
        }

        public void AddAllItemsToCart()
        {
            var items = elementInteractor.LocateElements(Locator.ClassName("inventory_item"));
            foreach (var item in items)
            {
                var addButton = elementInteractor.LocateChildElement(item, Locator.XPath(".//button[text()='Add to cart']"));
                addButton.Click();
            }
        }

        public int GetCartCount()
        {
            var locator = Locator.ClassName("shopping_cart_badge");
            var badges = elementInteractor.LocateElements(locator);
            if (badges.Count > 0)
            {
                return int.Parse(badges[0].Text);
            }
            else
            {
                return 0;
            }
        }

        public void ViewProductDetails(string productName)
        {
            var locator = Locator.XPath($"//div[text()='{productName}']");
            elementInteractor.ClickElement(locator);
        }

        public string FetchProductName()
        {
            var locator = Locator.CssSelector(".inventory_details_name.large_size");
            return elementInteractor.LocateElement(locator).Text;
        }

        public void SortBy(string option)
        {
            var locator = Locator.ClassName("product_sort_container");
            elementInteractor.SelectOption(locator, option);
        }

        public bool IsAscending<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            return list.SequenceEqual(list.OrderBy(x => x));
        }

        public bool IsDescending<T>(IEnumerable<T> list)
        {
            return list.SequenceEqual(list.OrderByDescending(x => x));
        }

        public List<string> InventoryNames()
        {
            var items = elementInteractor.LocateElements(Locator.ClassName("inventory_item"));
            var names = new List<string>();
            foreach (var item in items)
            {
                var name = elementInteractor.LocateChildElement(item, Locator.CssSelector(".inventory_item_name")).Text;
                names.Add(name);
            }
            return names;
        }

        public List<float> InventoryPrices()
        {
            var items = elementInteractor.LocateElements(Locator.ClassName("inventory_item"));
            var prices = new List<float>();
            foreach (var item in items)
            {
                var priceText = elementInteractor.LocateChildElement(item, Locator.CssSelector(".inventory_item_price")).Text;
                var price = float.Parse(priceText.Substring(1)); // Remove the currency symbol
                prices.Add(price);
            }
            return prices;
        }

        public void GoToCart()
        {
            var locator = Locator.ClassName("shopping_cart_link");
            elementInteractor.ClickElement(locator);
        }

        public bool VerifyAddToCartStatus(string productName)
        {
            var locator = Locator.XPath($"//div[@class='inventory_item' and .//div[text()='{productName}']]//button[text()='Remove']");
            return elementInteractor.IsElementVisible(locator);

        }
        public bool VerifyRemoveFromCartStatus(string productName)
        {
            var locator = Locator.XPath($"//div[@class='inventory_item' and .//div[text()='{productName}']]//button[text()='Add to cart']");
            return elementInteractor.IsElementVisible(locator);
        }
        /*        DriverUtils driverUtils;
                WebDriverWait wait;
                public ProductPage(IWebDriver driver)
                {
                    driverUtils = new DriverUtils(driver);
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                }
                public void AddProductToCart(string productname)
                {
                    driverUtils.LocateElement(By.XPath($"//div[@class='inventory_item' and .//div[text()='{productname}']]//button[text()='Add to cart']")).Click();
                }
                public void RemoveProductFromCart(string productname)
                {
                    driverUtils.LocateElement(By.XPath($"//div[@class='inventory_item' and .//div[text()='{productname}']]//button[text()='Remove']")).Click();
                }
                public void AddAllItemsToCart()
                {
                    //IList<IWebElement> items = driverUtils.LocateAll(By.ClassName("inventory_item"));
                    foreach (IWebElement item in driverUtils.LocateElements(By.ClassName("inventory_item")))
                    {
                        item.FindElement(By.XPath(".//button[text()='Add to cart'] ")).Click();
                    }
                }
                public int GetCartCount()
                {
                    By element = By.ClassName("shopping_cart_badge");
                    //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_badge")));
                    var badges =driverUtils.LocateElements(element);
                    if (badges.Count() > 0)
                    {
                        return int.Parse(badges[0].Text);
                    }
                    else
                        return 0;
                    //if (driverUtils.Locate(By.ClassName("shopping_cart_badge")).Enabled)
                    //    return int.Parse(driverUtils.Locate(By.ClassName("shopping_cart_badge")).Text);
                    //else 
                    //    return 0;
                }
                public void ViewProductDetails(string productname)
                {
                    driverUtils.LocateElement(By.XPath($"//div[text()='{productname}']")).Click();
                }
                public string FetchProductName()
                {
                    return driverUtils.LocateElement(By.CssSelector(".inventory_details_name.large_size")).Text;
                }
                public void Sortby(string option)
                {
                    driverUtils.SelectOption(option);
                }
                public bool IsAscending<T>(IEnumerable<T> list) where T : IComparable<T>
                {
                    return list.SequenceEqual(list.OrderBy(x => x));
                }
                public bool IsDescending<T>(IEnumerable<T> list) where T : IComparable<T>
                {
                    return list.SequenceEqual(list.OrderByDescending(x => x));
                }
                public List<string> InventoryNames()
                {
                    List<string> list = new List<string>();
                    foreach (IWebElement item in driverUtils.LocateElements(By.ClassName("inventory_item")))
                    {
                        //Getattribute, fetch attribute style  : color
                        list.Add(item.FindElement(By.CssSelector(".inventory_item_name ")).Text);   
                    }
                    return list;
                }
                public List<float> InventoryPrices()
                {
                    List<float> list = new List<float>();
                    foreach (IWebElement item in driverUtils.LocateElements(By.ClassName("inventory_item")))
                    {
                        var ROI= new string(item.FindElement(By.CssSelector(".inventory_item_price")).Text.Skip(1).ToArray());
                        Console.WriteLine(ROI);
                        list.Add(float.Parse(ROI));
                    }
                    return list;
                }
                public void GoToCart()
                {
                    driverUtils.LocateElement(By.ClassName("shopping_cart_link")).Click();
                }*/
    }
}

using AutomationFrameworkUtilities;

namespace PageObjectModel
{
    public class LoginPage
    {
        ElementInteractor elementInteractor;
        Waits waits;
        public LoginPage(ElementInteractor elementInteractor, Waits waits)
        {
            this.elementInteractor = elementInteractor;
            this.waits = waits;
        }
        public void EnterUsername(string username)
        {
            elementInteractor.SendKeysToElement(Locator.Id("user-name"), username);
        }

        public void EnterPassword(string password)
        {
            elementInteractor.SendKeysToElement(Locator.Id("password"), password);
        }

        public void ClickLoginButton()
        {
            elementInteractor.ClickElement(Locator.Id("login-button"));
        }

        public bool IsErrorMessageDisplayed(string message)
        {
            return waits.WaitForTextToBePresentInElement(Locator.CssSelector(".error-message-container"), message);
        }

        /*        //IWebDriver driver;
                DriverUtils driverUtils;
                public LoginPage(IWebDriver driver) 
                {
                    //this.driver = driver;
                    driverUtils = new DriverUtils(driver);
                }
                public void Username(string uname)
                {
                    driverUtils.LocateElement(By.Id("user-name")).SendKeys(uname);
                }
                public void Password(string pwd)
                {
                    driverUtils.LocateElement(By.Id("password")).SendKeys(pwd);
                }
                public string FetchErrorMessage()
                {
                    return driverUtils.LocateElement(By.CssSelector(".error-message-container")).Text;

                }
                public void ClickLogin()
                {
                    driverUtils.LocateElement(By.Id("login-button")).Click();
                }
        */

    }
}

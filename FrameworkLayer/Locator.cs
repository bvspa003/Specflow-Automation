using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class Locator
    {
        public string LocatorType { get; }
        public string LocatorValue { get; }

        private Locator(string locatorType, string locatorValue)
        {
            LocatorType = locatorType;
            LocatorValue = locatorValue;
        }

        public static Locator Id(string id)
        {
            return new Locator("Id", id);
        }

        public static Locator Name(string name)
        {
            return new Locator("Name", name);
        }

        public static Locator ClassName(string className)
        {
            return new Locator("ClassName", className);
        }

        public static Locator CssSelector(string cssSelector)
        {
            return new Locator("CssSelector", cssSelector);
        }

        public static Locator XPath(string xpath)
        {
            return new Locator("XPath", xpath);
        }
    }
}

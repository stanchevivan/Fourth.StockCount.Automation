using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace StockCount.Tests
{
    public static class Get
    {
        public static List<string> Classes(IWebElement element)
		{
			return element.GetAttribute("class").Split(' ').ToList();
		}

		public static bool HasClass(this IWebElement element, string className)
		{
            return Classes(element).Contains(className);
		}

        public static string Text(IWebElement element)
        {
            return element.Text;
        }

        public static bool ElementPresent(IWebElement element)
        {
            try
            {
                var t = element.TagName;
			}
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public static bool ElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
    }
}

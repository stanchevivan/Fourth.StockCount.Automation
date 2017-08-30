using System.Collections.Generic;
using OpenQA.Selenium;

namespace StockCount.Tests.CustomClasses
{
    public class Product
    {
        public IWebElement Webelement;

        public string UOM;
        public string Quantity;

        public string Name;
        public Dictionary<string, int> UOMandQuantity = new Dictionary<string, int>();

		public void SetQuanitity(int quantity)
		{
			Webelement.FindElement(By.TagName("input")).Clear();
			Webelement.FindElement(By.TagName("input")).SendKeys(quantity.ToString());
		}
    }
}

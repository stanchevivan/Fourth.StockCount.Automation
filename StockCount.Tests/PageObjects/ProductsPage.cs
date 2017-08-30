using System.Collections.Generic;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StockCount.Tests.CustomClasses;

namespace TestAutomationStockCount.StockCount.Tests
{
    public class ProductsPage : BasePage
    {
		#region Constructor
        ProductsPage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.CssSelector, Using = ".product-list > div")]
        private IList<IWebElement> LST_Products { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-home")]
        private IWebElement IconHome { get; set; }
        #endregion

        public List<Product> Products => GetProducts();
        
        #region Methods
        public void Out_ProductDetails(Product product)
        {
            System.Console.WriteLine("Product:\n" + product.Name);
            foreach (var UOM in product.UOMandQuantity)
            {
                System.Console.WriteLine(UOM.Key + ": " + UOM.Value);
            }
        }

        public void ClickHomeIcon()
        {
            IconHome.Click();
        }

        private List<Product> GetProducts()
        {
            List<Product> tempList = new List<Product>();

            foreach (var p in LST_Products)
			{
                Product tempProduct = new Product
                {
                    Webelement = p,
                    Name = p.FindElement(By.ClassName("product-list-item__description")).Text,
                };
                var UOMlist = p.FindElements(By.ClassName("product-list-item__attribute"));
				
                foreach (var uom in UOMlist)
				{
                    string unitName = uom.FindElement(By.ClassName("product-list-item__attribute__unit")).Text;
                    int quantity = int.Parse(uom.FindElement(By.CssSelector(".product-list-item__attribute__quantity > input")).GetAttribute("value"));
                    tempProduct.UOMandQuantity.Add(unitName, quantity);
				}

                tempList.Add(tempProduct);
			}

            return tempList;
        }

        /*
        public void SetQuantity(this IWebElement product, int quantity)

			product.FindElement(By.TagName("input")).Clear();
			product.FindElement(By.TagName("input")).SendKeys(quantity.ToString());
        }*/
        #endregion
    }
}

using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StockCount.Tests;

namespace TestAutomationStockCount.StockCount.Tests
{
    public class FourthHomePage : BasePage
    {
		#region Constructor
        public FourthHomePage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Stock Count']")]
        private IWebElement LNK_StockCount { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-interface-sidebar-hamburger")]
		private IWebElement ICN_Hamburger { get; set; }
		[FindsBy(How = How.ClassName, Using = "menu-minimised")]
        private IWebElement MinimizedMenu { get; set; }
		#endregion

		#region Methods
        private void SwitchToTab()
		{
			Driver.AsMobile().SwitchToWebViewContext();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
		}

        public SCLocationPage OpenStockCount()
        {
            if (MinimizedMenu.Exist())
            {
                Do.Click(ICN_Hamburger);
            }

            Driver.WaitElementToExists(LNK_StockCount);
            LNK_StockCount.Click();
            SwitchToTab();

            return new SCLocationPage(Driver);
        }
        #endregion
    }
}

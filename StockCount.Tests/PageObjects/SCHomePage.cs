using System.Collections.Generic;
using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StockCount.Tests;

namespace TestAutomationStockCount.StockCount.Tests
{
    public class SCHomePage : BasePage
    {
		#region Constructor
        public SCHomePage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.TagName, Using = "md-card")]
        private IList<IWebElement> LST_Areas { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-home")]
		private IWebElement IconHome { get; set; }
        [FindsBy(How = How.ClassName, Using = "stock-period__label")]
		private IWebElement LBL_StockPeriod { get; set; }
		[FindsBy(How = How.CssSelector, Using = "button.md-headline")]
        private IWebElement BTN_NewArea { get; set; }
		[FindsBy(How = How.ClassName, Using = "area-card__new-title")]
		private IWebElement FLD_NewAreaName { get; set; }
        [FindsBy(How = How.CssSelector, Using = "md-card-actions button:last-of-type")]
        private IWebElement BTN_ConfirmNewAreaName { get; set; }
		[FindsBy(How = How.XPath, Using = "//button/span[text() = 'Edit area']")]
		private IWebElement BTN_EditArea { get; set; }
		[FindsBy(How = How.XPath, Using = "//button/span[text() = 'Delete area']")]
		private IWebElement BTN_DeleteArea { get; set; }
        [FindsBy(How = How.TagName, Using = "textarea")]
        private IWebElement FLD_TextArea { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-tick")]
        private IWebElement BTN_TickButton { get; set; }
        [FindsBy(How = How.TagName, Using = "md-backdrop")]
		private IWebElement backdrop { get; set; }
        #endregion

        public List<string> AreaNamesList => LST_Areas.Select(x => x.FindElement(By.CssSelector("md-card-title span:first-of-type")).Text).ToList();

        #region Methods
        public void OpenArea(string areaName)
        {
            LST_Areas.First(x => x.FindElement(By.CssSelector("md-card-title span:first-of-type")).Text == areaName).Click();
            Driver.WaitElementToExists(IconHome);
        }

        public SCHomePage RenameArea(string oldName, string newName)
        {
            var areaCard = LST_Areas.First(x => x.FindElement(By.CssSelector("md-card-title-text>span:first-of-type")).Text == oldName);
            areaCard.FindElement(By.CssSelector("div button")).Click();
            Do.Click(BTN_EditArea);
            Do.ClearAndSendKeys(FLD_TextArea, newName);
            Driver.WaitElementToDisappear(backdrop);
            Driver.WaitIsClickable(BTN_TickButton);
            Do.Click(BTN_TickButton);

            return this;
        }

		public SCHomePage RenameArea(int index, string newName)
		{
            var areaCard = LST_Areas[index - 1];
			areaCard.FindElement(By.CssSelector("div button")).Click();
			Do.Click(BTN_EditArea);
			Do.ClearAndSendKeys(FLD_TextArea, newName);
			Driver.WaitElementToDisappear(backdrop);
			Driver.WaitIsClickable(BTN_TickButton);
			Do.Click(BTN_TickButton);

			return this;
		}

        public bool IsLabelStockPeriodPresent()
        {
            return LBL_StockPeriod.Displayed;
        }

        public SCHomePage UseNewAreaButton()
        {
            BTN_NewArea.Click();
            //Driver.WaitIsClickable(BTN_ConfirmNewAreaName);

            return this;
        }

        public SCHomePage ConfirmNewAreaName()
        {
            BTN_ConfirmNewAreaName.Click();

            return this;
        }

        public SCHomePage EnterNewAreaName(string name)
        {
            FLD_NewAreaName.ClearAndSendKeys(name);

            return this;
        }

        public SCHomePage CreateNewArea(string name)
        {
            UseNewAreaButton();
            EnterNewAreaName(name);
            ConfirmNewAreaName();

            return this;
        }
        #endregion
    }
}

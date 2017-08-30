using System.Collections.Generic;
using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationStockCount.StockCount.Tests
{
    public class SCLocationPage : BasePage
    {
		#region Constructor
        public SCLocationPage(IWebDriver webDriver) : base(webDriver)
        {
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.ClassName, Using = "ember-basic-dropdown-trigger")]
        private IWebElement DDL_Location { get; set; }
        [FindsBy(How = How.ClassName, Using = "location-picker__button")]
        private IWebElement BTN_Confirm { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[role=option]")]
        private IList<IWebElement> LST_Locations { get; set; }
        [FindsBy(How = How.ClassName, Using = "screen-loading")]
		private IWebElement LoadingScreen { get; set; }
		[FindsBy(How = How.ClassName, Using = "md-select-menu-container")]
		private IWebElement Panel_LocationList { get; set; }

		#endregion

		#region Methods
        public SCLocationPage SelectLocation(string location)
        {
			Driver.WaitIsClickable(DDL_Location);
			DDL_Location.Click();

            Driver.WaitIsClickable(Panel_LocationList);

            // Need custom wait for this
            //// Driver.JavaScript().ExecuteJavaScript(string.Format("return $('#{0}').is(':animated')", Panel_LocationList.GetAttribute("id")));

            LST_Locations.First(x => x.Text == location).Click();
            Driver.WaitElementToDisappear(Panel_LocationList);

            return this;
        }

        public SCHomePage Confirm()
        {
            BTN_Confirm.Click();
            if(LoadingScreen.Exist())
            {
                Driver.WaitElementToDisappear(LoadingScreen);
            }

            return new SCHomePage(Driver);
        }

        public SCHomePage ChooseLocation(string location)
        {
            SelectLocation(location);
            Confirm();

            return new SCHomePage(Driver);
        }

        public int GetNumberOfLocations()
        {
            DDL_Location.Click();
            Driver.WaitIsClickable(Panel_LocationList);
            Panel_LocationList.Click();
            Driver.WaitElementToDisappear(Panel_LocationList);

            return LST_Locations.Count;
        }
        #endregion
    }
}

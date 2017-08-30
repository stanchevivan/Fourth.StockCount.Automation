using OpenQA.Selenium;

namespace StockCount.Tests
{
    public static class Do
    {
        public static void Click(IWebElement element)
		{
            element.Click();
        }

        public static void ClearAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void Clear(IWebElement element)
        {
            element.Clear();
        }
    }
}

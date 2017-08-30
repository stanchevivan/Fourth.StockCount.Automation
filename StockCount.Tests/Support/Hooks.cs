using TechTalk.SpecFlow;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using BoDi;
using OpenQA.Selenium;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Mobile.Appium;

namespace Fourth.Automation.Examples.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private readonly AppiumDebugServers appiumServers;

        private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
            this.objectContainer = container;
            this.appiumServers = new AppiumDebugServers(
                new TerminalCommand[] {
                    new AppiumServer(DriverFactory.DriverInfo),
                    new IOSWebkitDebugProxy(DriverFactory.DriverInfo) });
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DriverFactory.Resolvers.Add(new AndroidResolver());
            DriverFactory.Resolvers.Add(new IOSResolver());
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.appiumServers.Start(DriverFactory.DriverInfo);
            driver = DriverFactory.Create();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            this.appiumServers.Stop();
        }
    }
}


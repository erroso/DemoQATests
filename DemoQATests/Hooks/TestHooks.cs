using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DemoQATests.Hooks
{

    [Binding]
    public class TestHooks
    {
        [BeforeScenario]
        public void createWebDriver(ScenarioContext context)
        {
            // coloquei chrome mas poderia ser qualquer browser
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            IWebDriver webDriver = new ChromeDriver(options);
            context["WEB_DRIVER"] = webDriver;

        }



        [AfterScenario]
        public void closeWebDriver(ScenarioContext context)
        {
            var driver = context["WEB_DRIVER"] as IWebDriver;
            driver.Quit();
            driver = null;
        }


    }
}

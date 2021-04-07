using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace DemoQATests.PageObjects
{
    public abstract class BasePage
    {

        private IWebDriver driver;
        private DefaultWait<IWebDriver> fluentWait;
        private int timeOut = 5; //seconds
        private int pollingInterval = 250; //miliseconds

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeOut);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            // ignore thse exceptions
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(WebDriverException));
            fluentWait.Message = "Element not found";
            PageFactory.InitElements(driver, this);
        }

         
        private void changeImplicitWait(double value)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value);

        }

        private void restoreDefaultImplicitWait()
        {
            changeImplicitWait(timeOut);
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public DefaultWait<IWebDriver> getFluentWait()
        {
            return fluentWait;
        }

        bool isElementOnPage(IWebElement element)
        {
            changeImplicitWait(1);
            bool isElementOnPage = true;
            try
            {
                // Get location on WebElement is rising exception when element is not present
                _ = element.Location;
            }
            catch (WebDriverException ex)
            {
                isElementOnPage = false;
            }
            finally
            {
                restoreDefaultImplicitWait();
            }
            return isElementOnPage;
        }
    }
}
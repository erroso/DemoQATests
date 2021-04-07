using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQATests.PageObjects
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver)
            : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "userName-value")]
        private IWebElement userName_textbox;


        public bool isUserNameOnPage()
        {
            return isElementOnPage(userName_textbox);
        }

    }
}

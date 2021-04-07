using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQATests.PageObjects
{
    public class ProfilePage : BasePage
    {

        string url = "https://demoqa.com/profile";


        public ProfilePage(IWebDriver driver)
            : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "userName-value")]
        private IWebElement userName_textbox;

        [FindsBy(How = How.Id, Using = "searchBox")]
        private IWebElement searchBox_textbox;

   
        public bool isUserNameOnPage()
        {
            return isElementOnPage(userName_textbox);
        }

        public void goToPage()
        {
            getDriver().Navigate().GoToUrl(url);
        }

        public void searchFor(string str1)
        {
            searchBox_textbox.SendKeys(str1);
        }
    }
}

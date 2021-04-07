using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;

namespace DemoQATests.PageObjects
{
    public class LoginPage : BasePage
    {
        
        string _url = "https://demoqa.com/login";
       
     

        public LoginPage(IWebDriver driver)
            : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement userName_textbox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password_textbox;

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement login_button;

        [FindsBy(How = How.Id, Using = "newUser")]
        private IWebElement newUser_button;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement logout_button;

        public void goToPage()
        {
            getDriver().Navigate().GoToUrl(_url);
        }

        public void clickNewUser()
        {
            newUser_button.Click();
        }
  
        public void GerarScreenshot(string scenario)
        {
            ChromeDriver x = (ChromeDriver) getDriver();
            x.GetScreenshot().SaveAsFile("C:\\temp\\" + $"{scenario}_{DateTime.Now:yyyyMMddHHmmss}.Png",
                ScreenshotImageFormat.Png);
        }



    }
}

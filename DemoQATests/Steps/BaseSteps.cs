using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using DemoQATests.PageObjects;

namespace DemoQATests.Steps
{
    [Binding]
    public class BaseSteps
    {
       
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private LoginPage _loginPage;
        private RegisterPage _registerPage;
        private ProfilePage _profilePage;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        public ScenarioContext getScenario()
        {
            return _scenarioContext;
        }

        public IWebDriver getDriver()
        {
            return _webDriver;
        }

        public LoginPage getLoginPage()
        {
            if (_loginPage == null)
            {
                _loginPage = new LoginPage(_webDriver);
            }
            return _loginPage;
        }

        public RegisterPage getRegisterPage()
        {
            if (_registerPage == null)
            {
                _registerPage = new RegisterPage(_webDriver);
            }
            return _registerPage;
        }

        public ProfilePage getProfilePage()
        {
            if (_profilePage == null)
            {
                _profilePage = new ProfilePage(_webDriver);
            }
            return _profilePage;
        }

    }
}

using DemoQATests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using DemoQATests.Helpers;
using FluentAssertions;
using DemoQATests.Hooks;

namespace DemoQATests.Steps
{
    [Binding]
    public sealed class ChallengeSteps : BaseSteps
    {
        User _user;
        RegisterPage register;
        
        public ChallengeSteps(ScenarioContext scenarioContext):
            base(scenarioContext)
        {
            
        }

        [Given(@"the user navigate to the login page")]
        public void GivenTheUserNavigateToTheLoginPage()
        {
            getLoginPage().goToPage();
        }

        [Given(@"he goes to the user registration page")]
        public void GivenHeGoesToTheUserRegistrationPage()
        {
            getLoginPage().clickNewUser();
        }

        [When(@"he fills in the registration of a new user with the correct data")]
        public void WhenHeFillsInTheRegistrationOfANewUserWithTheCorrectData()
        {
            _user = getRegisterPage().fillAllRegistrationFieldsRandomly();
        }

        [Then(@"the data was filled in correctly way")]
        public void ThenTheDataWasFilledInCorrectlyWay()
        {
            var registerPage = getRegisterPage();
            registerPage.isFirstName(_user.FirstName).Should().BeTrue();
            registerPage.isLastName(_user.LastName).Should().BeTrue();
            registerPage.isUserName(_user.UserName).Should().BeTrue();
            registerPage.isPassword(_user.Password).Should().BeTrue();
        }

        [Then(@"the user confirm the registration")]
        public void ThenTheUserConfirmTheRegistration()
        {
            Login user = new Login()
            {
                userName = _user.UserName,
                password = _user.Password
            };
            var answer = AccountAPI.registerUser(user);
            answer.StatusCode.ToString().Should().Be("Created");
        }

        [Then(@"the user logs in, confirming that the registration was successfully")]
        public void ThenTheUserLogsInConfirmingThatTheRegistrationWasSuccessfully()
        {
            var loginPage = getLoginPage();
            loginPage.goToPage();
            loginPage.login(_user.UserName, _user.Password);
            var profilePage = getProfilePage();
            if(profilePage.isUserNameOnPage())
            {
                profilePage.Screenshot(getScenario().ScenarioInfo.Title);
            }
            
            

        }


    }
}

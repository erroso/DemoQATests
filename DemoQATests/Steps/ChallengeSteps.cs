using DemoQATests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using DemoQATests.Helpers;
using FluentAssertions;

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
            getRegisterPage().isFirstName(_user.FirstName).Should().BeTrue();
            getRegisterPage().isLastName(_user.LastName).Should().BeTrue();
            getRegisterPage().isUserName(_user.UserName).Should().BeTrue();
            getRegisterPage().isPassword(_user.Password).Should().BeTrue();
        }


    }
}

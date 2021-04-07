using DemoQATests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using DemoQATests.Helpers;
using FluentAssertions;
using DemoQATests.Hooks;
using System.Threading;

namespace DemoQATests.Steps
{
    [Binding]
    public sealed class ChallengeSteps : BaseSteps
    {
        User _user;
        RegisterPage _register;
        string _tag;
        
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

        [Given(@"the authenticated user navigates to profile page")]
        public void GivenTheAuthenticatedUserNavigatesToProfilePage()
        {
            var loginPage = getLoginPage();
            loginPage.goToPage();
            loginPage.login("Barão de Maua", "Baraodemaua12#");

        }

        [When(@"he fills in the registration of a new user with the correct data")]
        public void WhenHeFillsInTheRegistrationOfANewUserWithTheCorrectData()
        {
            _user = getRegisterPage().fillAllRegistrationFieldsRandomly();
        }


        [When(@"the user searches a specific book using the tag ""(.*)""")]
        public void WhenTheUserSearchesASpecificBookUsingTheTag(string p0)
        {
            
            var booksPage = getBooksPage();
            booksPage.goToPage();
            _tag = p0;
            booksPage.searchFor(_tag);
            booksPage.Screenshot(getScenario().ScenarioInfo.Title);
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

        [Then(@"a list of all books with this tag appears")]
        public void ThenAListOfAllBooksWithThisTagAppears()
        {
            var hasText = getBooksPage().checkAllBooksHaveText(_tag);
            hasText.Should().BeTrue();
        }

        [Then(@"the user add the book number '(.*)' of the list to his book collection")]
        public void ThenTheUserAddTheBookNumberOfTheListToHisBookCollection(int p0)
        {
            var bookPage = getBooksPage();
            var bookTitle = bookPage.getBookName(p0);
            bookPage.clickOnText(bookTitle);
            bookPage.addToCollection();
            Thread.Sleep(2000);
            bookPage.printAllScreen();
            
                 
        }




    }
}

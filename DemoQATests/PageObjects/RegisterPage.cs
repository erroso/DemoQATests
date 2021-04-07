using DemoQATests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace DemoQATests.PageObjects
{
    public class RegisterPage : BasePage
    {
        public static string _url = "http://demoqa.com/register";

        public RegisterPage(IWebDriver driver)
            : base(driver)
        {

        }


        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement firstname_textbox;

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement lastname_textbox;

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement userName_textbox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password_textbox;

        [FindsBy(How = How.Id, Using = "register")]
        private IWebElement register_button;

        [FindsBy(How = How.Id, Using = "gotologin")]
        private IWebElement gotologin_button;
        

        public void fillFirstName(string str)
        {
            firstname_textbox.SendKeys(str);
        }

        public void fillLastName(string str)
        {
            lastname_textbox.SendKeys(str);
        }

        public void fillUserName(string str)
        {
            userName_textbox.SendKeys(str);
        }

        public void fillPassword(string str)
        {
            password_textbox.SendKeys(str);
        }

        public User fillAllRegistrationFieldsRandomly()
        {
            bool allUserData = true;
            var user = UserBuilder.getRamdomUser(allUserData);
            return fillAllRegistrationFields(user.FirstName, user.LastName, user.UserName, user.Password);
           
        }
        public User fillAllRegistrationFields(string str1, string str2, string str3, string str4)
        {
            fillFirstName(str1);
            fillLastName(str2);
            fillUserName(str3);
            fillPassword(str4);
            var user = new User()
            {
                FirstName = str1,
                LastName = str2,
                UserName = str3,
                Password = str4
            };
            return user;
        }

        public bool isFirstName(string str)
        {
            var answer = false;
            if (firstname_textbox.GetAttribute("value") == str)
            {
                answer = true;
            }
            return answer;
        }

        public bool isLastName(string str)
        {
            var answer = false;
            if (lastname_textbox.GetAttribute("value") == str)
            {
                answer = true;
            }
            return answer;
        }

        public bool isUserName(string str)
        {
            var answer = false;
            if (userName_textbox.GetAttribute("value") == str)
            {
                answer = true;
            }
            return answer;
        }

        public bool isPassword(string str)
        {
            var answer = false;
            if (password_textbox.GetAttribute("value") == str)
            {
                answer = true;
            }
            return answer;
        }

    }
}

using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using DemoQATests.Helpers;
using System.Collections.Generic;
using WindowsInput;


namespace DemoQATests.PageObjects
{
    public class BooksPage : BasePage
    {
        private const string url = "https://demoqa.com/books";
        private List<Book> _books;
        

        public BooksPage(IWebDriver driver)
           : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "searchBox")]
        private IWebElement search_textbox;

        [FindsBy(How = How.Id, Using = "addNewRecordButton")]
        private IWebElement addNewRecordButton;

        
        public void goToPage()
        {
            getDriver().Navigate().GoToUrl(url);
        }

        public void searchFor(string str)
        {
            if (isElementOnPage(search_textbox))
            {
                search_textbox.SendKeys(str);
            }
        }

        public void addToCollection()
        {
            if (isElementOnPage(addNewRecordButton))
            {
                addNewRecordButton.Click();
            }
            
        }

        public void printAllScreen()
        {
            
            InputSimulator sim = new InputSimulator();
       
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LWIN);
            sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SNAPSHOT);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LWIN);
        }

        public void printBookDatailsOnConsole(List<Book> books)
        {
            var count = books.Count;
            foreach (var book in books)
            {
                Console.WriteLine("Livro " + book.Title + " do autor " + book.Author + " publicado por " + book.Publisher + ", foi encontrado entre os " + count + " resultados da pesquisa.");
            }
        }

        public string getBookName(int i)
        {
            return _books[i-1].Title;
        }

        public void clickOnText(string str1)
        {
            var element = getDriver().FindElement(By.PartialLinkText(str1));
            element.Click();
        }


        public bool checkAllBooksHaveText(string str2)
        {
            var rowsgroup = getDriver().FindElements(By.ClassName("rt-tr-group"));
            List<Book> books = new List<Book>();
            foreach (var row in rowsgroup)
            {
               var rawText = row.Text;
               if(rawText != "    " && !rawText.Contains(str2))
                {
                    return false;
                }
                else if(rawText != "    ")
                {
                    string[] column = rawText.Split("\r\n");
                    var book = new Book()
                    {
                        Title = column[0],
                        Author = column[1],
                        Publisher = column[2]
                    };
                    books.Add(book);
                }
            }
            _books = books;
            printBookDatailsOnConsole(books);
            return true;
        }


    }
   
}



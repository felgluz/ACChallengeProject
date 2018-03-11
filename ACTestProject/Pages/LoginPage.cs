using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ACTestProject.Pages
{

    class LoginPage
    {
        public LoginPage()
        {
            //PageFactory.InitElements(Browser.GetDriver(Drivers.Chrome), this);
        }

        public int timeout = 5;

        public IWebElement txtEmail => Browser.Driver.FindElement(By.Id("user_email"));

        public IWebElement txtPassword => Browser.Driver.FindElement(By.Id("user_password"));

        public IWebElement btnSignIn => Browser.Driver.FindElement(By.Name("commit"));

        public void Login(string email, string password)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
        }

        public ToDoAppPage ClickSignInButton()
        {
            btnSignIn.Click();
            return new ToDoAppPage();
        }
    }
}


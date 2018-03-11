using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ACTestProject.Pages
{

    class LoginPage
    { 
        public LoginPage()
        {
            PageFactory.InitElements(Browser.GetDriver(Drivers.Chrome), this);
        }

        //[FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign In')]")]
        [FindsBy(How = How.LinkText, Using = "/users/sign_in")]
        public IWebElement navSignIn;

        [FindsBy(How = How.LinkText, Using = "/users/sign_in")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "Login")]
        public IWebElement btnLogin;

        public void ClickSignInNav()
        {
            navSignIn.Click();
        }

        public void ClickSignInButton()
        {
            btnSignIn.Click();
        }

        public void Login(string email, string password)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
        }

        public ToDoAppPage ClickLogin()
        {
            btnLogin.Submit();
            return new ToDoAppPage();
        }
    }
}

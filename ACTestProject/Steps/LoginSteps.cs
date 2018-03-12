using ACTestProject.Pages;
using TechTalk.SpecFlow;

namespace ACTestProject.Steps
{
    [Binding, Scope(Feature ="Login", Tag = "login")]    
    class LoginSteps
    {
        //[BeforeTestRun]
        //public void Initialize()
        //{
        //    Browser.Initialize();
        //}

        //[AfterTestRun]
        //public void TearDown()
        //{
        //    Browser.TearDown();
        //}

        LoginPage page = new LoginPage();

        [Given(@"I have navigated to the website")]
        public void GivenIHaveNavigatedToTheWebsite()
        {
            Browser.Initialize();
        }             

        [When(@"I type '(.*)' and '(.*)'")]
        public void WhenITypeAnd(string email, string password)
        {
            page.Login(email, password);
        }

        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {            
            PropertiesCollection.currentPage = page.ClickSignInButton();
        }
        
        [Then(@"I should see the ToDoApp page")]
        public void ThenIShouldSeeTheToDoAppPage()
        {
            //Casting
            ((HomePage)PropertiesCollection.currentPage).isLoggedIn();            
        }
    }
}

using ACTestProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ACTestProject.Steps
{
    [Binding]
    class LoginSeps
    {        
        LoginPage page = new LoginPage();

        [Given(@"I have navigated to the website")]
        public void GivenIHaveNavigatedToTheWebsite()
        {
            Browser.Initialize();
        }

        [Given(@"I click Sign In")]
        public void GivenIClickSignIn()
        {
            page.ClickSignInNav();
        }

        [When(@"I typed ""(.*)"" and ""(.*)""")]
        public void WhenITypedAnd(string emailField, string passwordField)
        {
            page.Login(emailField, passwordField);
        }

        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            page.ClickSignInButton();
        }
        
        [Then(@"I should see the ToDoApp page")]
        public void ThenIShouldSeeTheToDoAppPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

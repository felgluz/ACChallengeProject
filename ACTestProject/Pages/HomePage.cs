using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACTestProject.Pages
{
    class HomePage : BasePage
    {
        public IList<IWebElement> btnMyTasks => Browser.Driver.FindElements(By.XPath("//a[contains(text(),'My Tasks')]"));

        public void ClickOnMyTasksNavBar()
        {
            Assert.IsTrue(Browser.ElementIsPresent(By.XPath("//a[contains(text(),'My Tasks')]"), PropertiesCollection.timeoutInSeconds));
            btnMyTasks[0].Click();
        }

        public void ClickOnMyTasksButton()
        {
            Assert.IsTrue(Browser.ElementIsPresent(By.XPath("//a[contains(text(),'My Tasks')]"), PropertiesCollection.timeoutInSeconds));
            btnMyTasks[1].Click();
        }

        public void isLoggedIn()
        {
            Assert.IsTrue(Browser.ElementIsPresent(By.XPath("//a[contains(text(),'My Tasks')]"), PropertiesCollection.timeoutInSeconds));
        }
    }
}

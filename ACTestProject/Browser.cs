using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ACTestProject
{
    public enum Drivers
    {
        Chrome,
        Firefox,
        IE
    }

    public static class Browser
    {
        private static IWebDriver _webDriver;

        private static string baseUrl = "https://qa-test.avenuecode.com/users/sign_in";

        internal static IWebDriver GetDriver(Drivers driver)
        {
            switch (driver)
            {
                case Drivers.Chrome:
                    return new ChromeDriver();
                case Drivers.Firefox:
                    return new FirefoxDriver();
                default:
                    throw new NotImplementedException("Driver not found.");
            }
        }

        public static ISearchContext Driver
        {
            get { return _webDriver; }
        }

        public static void Goto()
        {
            _webDriver.Navigate().GoToUrl(baseUrl);
        }

        public static void UseEnterKey()
        {
            Actions action = new Actions(_webDriver);
            action.SendKeys(OpenQA.Selenium.Keys.Enter).Build().Perform();
        }
        
        #region Methods for wait
        public static bool ElementIsPresent(By element, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                if (ElementIsVisible(element))
                {
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        private static bool ElementIsVisible(By element)
        {
            var present = false;
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                present = _webDriver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return present;
        }
        #endregion

        #region Methods for Inicialization/Closing        
        public static void Initialize()
        {
            _webDriver = GetDriver(Drivers.Chrome);
            Goto();
            _webDriver.Manage().Window.Maximize();
        }

        public static void TearDown()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
        #endregion
    }
}

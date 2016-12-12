using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace WAG_tests
{

    [TestFixture()]
    public class TestBase
    {
      protected  FirefoxDriver firefox;

        [SetUp]
        public void StartBrowser()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            firefox.Navigate().GoToUrl("http://whiteaway.com/");
        }


        [TearDown]
        public void StopBrowser()
        {
            if (firefox != null)
            {
                firefox.Quit();
                firefox = null;
            }
        }



        protected void Logout()
        {
            firefox.FindElement(By.LinkText("Log af")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }


        protected void Login(string login, string pass)
        {
            firefox.FindElement(By.LinkText("Log ind")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            firefox.FindElement(By.Id("email_address")).SendKeys(login);
            firefox.FindElement(By.Id("password")).SendKeys(pass);
            firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }




        protected bool IsElementPresent(By by)
        {
            return firefox.FindElements(by).Count > 0;
        }


        protected bool LoggedInErrorDisplayed()
        {
            return IsElementPresent(By.LinkText("Fejl: E-mail -adressen eller kodeordet blev ikke genkendt."));
        }


        protected bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log af"));
        }



    }
}

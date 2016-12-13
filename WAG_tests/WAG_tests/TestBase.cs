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
      protected  IWebDriver firefox;
      WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            firefox = WebDriverFactory.GetDriver(DesiredCapabilities.Firefox());
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.Manage().Window.Maximize();
            firefox.Navigate().GoToUrl("http://whiteaway.com/");
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


        protected bool IsEmptySearch()
        {
            return IsElementPresent(By.CssSelector("span.search__suggest-zero"));
        }



        protected void InitializeSearch(string searchrequest)
        {
            firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).Clear();
            firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).SendKeys(searchrequest);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }



        protected void IsSearchResultsPresent(string searchrequest)
        {
            firefox.FindElement(By.CssSelector("a.search__suggest__see-all")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Assert.AreEqual(searchrequest, firefox.FindElement(By.Id("page_headline")).Text);
        }



        protected void SearchPageNavigationNext(string url, string nextpagenumber)
        {
            firefox.Navigate()
                    .GoToUrl(url);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.LinkText(nextpagenumber)).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }



        protected void SearchPageNavigationPrevious(string nextpagenumber)
        {
            String ptr = firefox.Url;
            if (ptr.Contains("side" + nextpagenumber)) firefox.FindElement(By.CssSelector("a.pageResults.pageResultsPrev")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }


    }
}

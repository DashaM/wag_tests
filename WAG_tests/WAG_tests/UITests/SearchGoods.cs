using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;

namespace WAG_tests
{
    [TestFixture()]
    public class SearchGoods : TestBase
    {
        private FirefoxDriver firefox;
        WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));
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


        [Test()]
        public void SearchBrand()
        {
           // firefox = new FirefoxDriver();
           // firefox.Manage().Window.Maximize();
           // try
           // {
                firefox.Navigate().GoToUrl("http://whiteaway.com/");
                //Thread.Sleep(3000);
                firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).Clear();
                firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).SendKeys("Bosch");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                firefox.FindElement(By.CssSelector("a.search__suggest__see-all")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                Assert.AreEqual("Bosch", firefox.FindElement(By.Id("page_headline")).Text);
           // }
           // finally { firefox.Quit(); }
        }


        [Test()]
        public void EmptySearch()
        {
           // firefox = new FirefoxDriver();
            //firefox.Manage().Window.Maximize();
           //try
           // {
                
                firefox.Navigate().GoToUrl("http://whiteaway.com/");
                firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).Clear();
                firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).SendKeys("qweqweqwe");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                firefox.FindElement(By.CssSelector("span.search__suggest-zero"))
                    .Text.Equals("Vi fandt desværre 0 resultater");
          //  }
           // finally { firefox.Quit();}

        }
    }
}

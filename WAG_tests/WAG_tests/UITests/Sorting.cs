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
    public class Sorting : TestBase
    {
       FirefoxDriver firefox;
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
        public void MovetoSecondResultsPage()
        {
           // firefox = new FirefoxDriver();
           // firefox.Manage().Window.Maximize();
          //  try
           // {
                firefox.Navigate()
                    .GoToUrl("http://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/");
                //Thread.Sleep(3000);
                firefox.FindElement(By.LinkText("2")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));


                String ptr = firefox.Url;
                if (ptr.Contains("side2")) firefox.FindElement(By.CssSelector("a.pageResults.pageResultsPrev")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                
           // }
           // finally { firefox.Quit(); }
        }


       
    }
}

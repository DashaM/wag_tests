using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System;
using NUnit.Framework;

namespace WAG_tests
{
    [TestFixture()]
    public class UserLogin : TestBase
    {
       // FirefoxDriver firefox;

   /* [SetUp]
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
    } */


        [Test()]
        public void WrongDataLogin()
        {
               Login("test.yhy@yopmail.com", "qwe");
            LoggedInErrorDisplayed();
        }


       

       [Test()]
        public void CorrectDataLogin()
        {
               Login("test.yhy@yopmail.com", "l5qjW");
               IsLoggedIn();
               Logout();
        }





     


    }
}


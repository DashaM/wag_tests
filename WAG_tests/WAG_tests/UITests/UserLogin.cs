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

     [Test()]
        public void WrongDataLogin()
        {
               Login("test.yhy@yopmail.com", "qwe");
            LoggedInErrorDisplayed();
        }


       

       [Test()]
        public void CorrectDataLogin()
        {
            Login("test.yhy@yopmail.com", "hkXm9");
               IsLoggedIn();
               Logout();
        }
    } 
}


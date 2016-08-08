using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System;
using NUnit.Framework;

namespace WAG_tests
{
    [TestFixture()]
    public class UserLogin
    {
        FirefoxDriver firefox;


       [Test()]
        public void WrongDataLogin()
        {
             firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
           try
           {
               //chrome = new ChromeDriver(@"D:\WAG_tests");
               firefox.Navigate().GoToUrl("http://whiteaway.com/");
               firefox.FindElement(By.LinkText("Log ind")).Click();
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
               firefox.FindElement(By.Id("email_address")).SendKeys("test.yhy@yopmail.com");
               firefox.FindElement(By.Id("password")).SendKeys("qqqqqq");
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
               firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

               firefox.FindElement(By.CssSelector("div.alert.alert-danger"))
                   .Text.Equals("Fejl: E-mail -adressen eller kodeordet blev ikke genkendt. ");
           }
           finally { firefox.Quit(); }
        }




       [Test()]
        public void CorrectDataLogin()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();

           try
           {
               // chrome = new ChromeDriver(@"D:\WAG_tests");
               firefox.Navigate().GoToUrl("http://prelive.whiteaway.com/");
               firefox.FindElement(By.LinkText("Log ind")).Click();
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
               firefox.FindElement(By.Id("email_address")).SendKeys("test.yhy@yopmail.com");
               firefox.FindElement(By.Id("password")).SendKeys("d8KU9");
               firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
               firefox.FindElement(By.LinkText("Log af")).Click();
               firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
           } finally { firefox.Quit(); }
        }

    }
}


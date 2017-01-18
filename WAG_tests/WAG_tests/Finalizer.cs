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

    [SetUpFixture]
    public class Finalizer
    {
         [OneTimeTearDown]    
       
        public void RunInTheEndOfAll()
        {
            WebDriverFactory.DismissAll();
        }
    }
}

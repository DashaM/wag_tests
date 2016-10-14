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
        [SetUp]
        public void StartApplication()
        {
            string browserType = System.Environment.GetEnvironmentVariable("BROWSER");
            string baseUrl = System.Environment.GetEnvironmentVariable("BASE_URL");
            string hubUrl = System.Environment.GetEnvironmentVariable("HUB_URL");

            if (baseUrl == null)
            {
                baseUrl = "http://whiteaway.com";
            }

        }
    }
}

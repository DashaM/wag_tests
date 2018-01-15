using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;

namespace WAG_tests
{
    [TestFixture()]
    public class NewCof : TestBase
    {

        [Test()]
        public void OneMdaNewCof()
        {

           

            AddCookieForNewCof();

            AddProductWithBonustoBasket("https://www.tretti.se/vitvaror/tvattmaskin/frontmatad-tvattmaskin/product/lg-q4j5tn4w/");
            


        }


  
        

    }
}

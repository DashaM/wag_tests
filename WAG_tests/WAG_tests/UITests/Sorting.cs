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
       

        [Test()]
        public void MovetoSecondResultsPage()
        {

            SearchPageNavigationNext("http://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/", "2");
            SearchPageNavigationPrevious("2");
    
        }




       

    }
}

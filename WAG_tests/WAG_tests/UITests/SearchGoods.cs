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

        [Test()]
        public void SearchBrand()
        {
                InitializeSearch("Bosch");
                IsSearchResultsPresent("Bosch");
        }


        [Test()]
        public void EmptySearch()
        {
            InitializeSearch("qweqweqwe");
            IsEmptySearch();
        }




    }
}

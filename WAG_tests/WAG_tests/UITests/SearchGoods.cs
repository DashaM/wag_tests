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



        [Test()]
        public void SearchResultFilter()
        {
            InitializeSearch("Blendere");
            IsSearchResultsPresent("Blendere");
            ApplyFilteronSRP("/html/body/div[3]/div[4]/div[2]/div[1]/div/div[6]/div/div/div/div",
                "/html/body/div[3]/div[4]/div[2]/div[1]/div/div[6]/div[2]/div/div[5]/label/div");
            IsFilterApplied();
        }
    }
}

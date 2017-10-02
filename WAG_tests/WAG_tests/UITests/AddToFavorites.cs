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
    public class AddToFavorites : TestBase
    {

        [Test()]
        public void AddToFavoritesList()
        {
            AddProductToFavorits("https://www.whiteaway.com/hvidevarer/toerretumbler/kondens-toerretumbler/product/aeg-t8dem842e/");
            OpenFavoritesList("T8DEM842E");
        }




        [Test()]
        public void DeleteFromFavoritesList()
        {
            AddProductToFavorits("https://www.whiteaway.com/hvidevarer/toerretumbler/kondens-toerretumbler/product/aeg-t8dem842e/");
            OpenFavoritesList("T8DEM842E");
            DeleteFavoriteProduct();
        }


  
        

    }
}

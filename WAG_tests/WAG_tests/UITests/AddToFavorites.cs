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
            AddProductToFavorits("https://www.whiteaway.com/hvidevarer/vaskemaskine/topbetjent-vaskemaskine/product/scandomestic-stl612/");
            OpenFavoritesList("STL612");
        }




        [Test()]
        public void DeleteFromFavoritesList()
        {
            AddProductToFavorits("https://www.whiteaway.com/hvidevarer/vaskemaskine/topbetjent-vaskemaskine/product/scandomestic-stl612/");
            OpenFavoritesList("STL612");
            DeleteFavoriteProduct();
        }


  
        

    }
}

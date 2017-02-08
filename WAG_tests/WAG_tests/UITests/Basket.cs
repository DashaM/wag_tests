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
    public class Basket : TestBase
    {

        [Test()]
        public void AddProducts()
        {
                ClearBasket();
                AddProductWithoutBonustoBasket("http://www.whiteaway.com/product/levering-indbaering-montering/");
                AddProductWithBonustoBasket("https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/bosch-waw32568sn-topmodel/");


        }


  
        

    }
}

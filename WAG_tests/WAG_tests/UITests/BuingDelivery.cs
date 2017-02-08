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
    public class BuyingDelivery : TestBase
    {

        [Test()]
        public void BuingDeliveryOnly()
        {

                AddProductWithoutBonustoBasket("http://www.whiteaway.com/product/levering-indbaering-montering/");
                StartCheckOutFlowFromBasketDeliveryonly();
                CheckOutFlowStep0Delivery();
                CheckOutFlowStep1Delivery();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                CheckOutFlowLastStep();
                FinalStep();


        }


  
        

    }
}

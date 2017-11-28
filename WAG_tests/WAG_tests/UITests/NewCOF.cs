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

            ClearBasket();

            AddNewCofCookie();

            AddProductWithBonustoBasket("https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/lg-q4j5tn4w/");
            StartCheckOutFlowFromBasket();
            SelectServiceMDA("3600", "/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[1]/label");
            CheckOutFlowStep0Delivery();
            CheckOutFlowStep2MDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            FinalStep();


        }


  
        

    }
}

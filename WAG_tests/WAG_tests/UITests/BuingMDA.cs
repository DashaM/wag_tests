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
    public class BuyingMDA  : TestBase
    {
      /*  FirefoxDriver firefox;
        WebDriverWait wait;
        // ChromeDriver chrome;

        [SetUp]
        public void StartBrowser()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));
        }


        [TearDown]
        public void StopBrowser()
        {
            if (firefox != null)
            {
                firefox.Quit();
                firefox = null;
            }
        } */


        [Test()]
        [Category("Long")]
        public void BuingMDA()
        {
            ClearBasket();

            AddProductWithBonustoBasket("https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/lg-testvinder/");
                StartCheckOutFlowFromBasket();
                SelectServiceMDA("3600", "/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[1]/label");
                CheckOutFlowStep0Delivery();
                CheckOutFlowStep2MDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                CheckOutFlowLastStep();
                FinalStep();

        }






        [Test()]
        public void BuingSeveralMDAsWithSlots()
        {
            ClearBasket();
              
            Add2ProducsToBasket(
                "https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/lg-testvinder/",
                "https://www.whiteaway.com/hvidevarer/komfur/induktions-komfur/product/gorenje-ei67322ax/");

                StartCheckOutFlowFromBasket();
                SelectServiceMDA("8000", "/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[1]/label");
                CheckOutFlowStep0Delivery2MDA();
                CheckOutFlowStep2MDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div");
                CheckOutFlowLastStep();
                FinalStep();
        }





        [Test()]
        public void BuingMDAWithSlots()
        {
            ClearBasket();

            AddProductWithBonustoBasket("https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/lg-testvinder/");
                StartCheckOutFlowFromBasket();
                SelectServiceMDA("3600");
                CheckOutFlowStep0Delivery();
                CheckOutFlowStep2MDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                CheckOutFlowLastStep();
                FinalStep();

        }





        [Test()]
        public void BuingMDAandSDA()
        {
            ClearBasket();
            
                Add2ProducsToBasket(
                   "https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/lg-testvinder/",
                   "https://www.whiteaway.com/koekkenudstyr/blender/blender/product/raw-pro-x1500-black-2-hk-2-0-l-2-generation/");

                StartCheckOutFlowFromBasket();
                SelectServiceMDA("3600");
                CheckOutFlowStep0DeliveryMDAPlusSDA();
                CheckOutFlowStep2MDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                CheckOutFlowLastStep();
                FinalStep();

        }

    }
}

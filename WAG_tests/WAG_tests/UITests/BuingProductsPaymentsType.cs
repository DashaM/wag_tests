﻿using System;

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace WAG_tests
{
    [TestFixture()]
    public class PaymentsType : TestBase
    {
        [Test()]
        public void Viabill()
        {
               ClearBasket();
               AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/barbering-trimning/barbermaskine/product/braun-5030s-maleshaver/");
               StartCheckOutFlowFromBasket();
               SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
               CheckOutFlowStep1SDA();
               CheckOutFlowStep2SDA();
               CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div/label/div/div[1]/div/div/div[2]");
               CheckOutFlowLastStep();
            ViabillMoveBackToShop();
               IsBackToStep();
               
      
        }


        [Test()]
        public void MobilePay()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/barbering-trimning/barbermaskine/product/braun-5030s-maleshaver/");
            StartCheckOutFlowFromBasket();
            SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
            CheckOutFlowStep1SDA();
            CheckOutFlowStep2SDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[3]/div[2]/div/label/div/div[1]/div/div");
            CheckOutFlowLastStep();
            MobilePayMoveBackToShop();
            IsBackToStep();


        }

    }
}
using System;

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
               AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
               StartCheckOutFlowFromBasket();
               SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
               CheckOutFlowStep1SDA();
               CheckOutFlowStep2SDA();
               CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div/label/div/div[1]/div/div/div[2]");
               IsDropCommentPresent();
            CheckOutFlowLastStep();
            ViabillMoveBackToShop();
               IsBackToStep();
        }


        [Test()]
        public void MobilePay()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
            StartCheckOutFlowFromBasket();
            SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
            CheckOutFlowStep1SDA();
            CheckOutFlowStep2SDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[3]/div[2]/div/label/div/div[1]/div/div");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            MobilePayMoveBackToShop();
            IsBackToStep();
        }



        [Test()]
        public void Dankort()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
            StartCheckOutFlowFromBasket();
            SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
            CheckOutFlowStep1SDA();
            CheckOutFlowStep2SDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[2]/div[2]/div/label[1]/div/div[1]/div");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            IsAltapayGatewayOpened();
        }


        [Test()]
        public void Mastercard()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
            StartCheckOutFlowFromBasket();
            SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
            CheckOutFlowStep1SDA();
            CheckOutFlowStep2SDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[2]/div[2]/div/label[2]/div/div[1]/div");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            IsAltapayGatewayOpened();
        }


        [Test()]
        public void OtherAltapayCards()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
            StartCheckOutFlowFromBasket();
            SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
            CheckOutFlowStep1SDA();
            CheckOutFlowStep2SDA();
            CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[2]/div[2]/div/label[3]/div/div[1]/div");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            IsAltapayGatewayOpened();
        }

    }
}
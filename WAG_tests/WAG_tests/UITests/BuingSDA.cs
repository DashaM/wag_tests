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
    public class BuyingSDA : TestBase
    {
        [Test()]
        public void BuingSDAWithoutServises()
        {
            ClearBasket();
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/helbred/blodtryksmaaler/product/braun-vitalscan/");
               StartCheckOutFlowFromBasket();
               SelectDeliveryOptionSDA("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[1]/div/div/div[2]/div/div/div/label[2]/div/div/div[1]/div/div");
               CheckOutFlowStep1SDA();
               CheckOutFlowStep2SDA();
               CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
            IsDropCommentPresent();
            CheckOutFlowLastStep();
            FinalStep();

        }


        [Test()]
        public void BuingSDAoutOfStockWithOption()
        {
            ClearBasket();
                //AddProductWithoutBonustoBasket("http://www.whiteaway.com/koekkenudstyr/blender/blender/product/kitchenaid-a-m-0-75l-krom/");
            AddProductWithoutBonustoBasket("https://www.whiteaway.com/personlig-pleje/haarpleje/curler/product/babyliss-3060e/");
                StartCheckOutFlowFromBasket();
               // SelectServiceSDA("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label");
                SelectDeliveryOptionSDA("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label/span");
                CheckOutFlowStep1SDA();
                CheckOutFlowStep2SDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                IsDropCommentPresent();
            CheckOutFlowLastStep();
            FinalStep();

        }

    }
}

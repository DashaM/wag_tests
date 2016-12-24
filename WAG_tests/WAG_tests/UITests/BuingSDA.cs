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
               AddProductWithoutBonustoBasket("http://whiteaway.com/stoevsuger/gulvrenser/product/nilfisk-nilfisk-smart-green-28/");
               StartCheckOutFlowFromBasketSDAOnly();
               SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
               CheckOutFlowStep1SDA();
               CheckOutFlowStep2SDA();
               CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
               CheckOutFlowLastStep();

        }


        [Test()]
        public void BuingSDAoutOfStockWithOption()
        {
                AddProductWithoutBonustoBasket("http://www.whiteaway.com/koekkenudstyr/blender/blender/product/kitchenaid-a-m-0-75l-krom/");
                StartCheckOutFlowFromBasket();
                SelectService("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]/div[1]/label");
                SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
                CheckOutFlowStep1SDA();
                CheckOutFlowStep2SDA();
                CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span");
                CheckOutFlowLastStep();

        }

    }
}

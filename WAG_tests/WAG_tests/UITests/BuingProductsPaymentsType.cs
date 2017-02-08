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
               AddProductWithoutBonustoBasket("http://whiteaway.com/stoevsuger/gulvrenser/product/nilfisk-nilfisk-smart-green-28/");
               StartCheckOutFlowFromBasket();
               SelectDeliveryOptionSDA("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input");
               CheckOutFlowStep1SDA();
               CheckOutFlowStep2SDA();
               CheckOutFlowStep3PaymentMethod("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div/label/div/div[1]/div/div/div[2]");
               CheckOutFlowLastStep();
            ViabillMoveBackToShop();
               IsBackToStep();
               
      
        }
    }
}
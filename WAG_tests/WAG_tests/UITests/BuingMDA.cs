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
    public class BuyingMDA : TestBase
    {
        FirefoxDriver firefox;
        WebDriverWait wait;
        // ChromeDriver chrome;

        [Test()]
        public void BuingMDA()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));

            try
            {

                firefox.Navigate()
                    .GoToUrl("https://www.whiteaway.com/hvidevarer/vaskemaskine/frontbetjent-vaskemaskine/product/bosch-waw32568sn-topmodel/");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/section[2]/div/div[2]/button")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                firefox.FindElement(By.LinkText("Kurv")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(4000);
                firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div/div/ng-view/div/div[1]/div[1]/div/div/div[2]/a")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

                Thread.Sleep(4000);
               // firefox.FindElement(By.XPath("/html/body/div[2]/div[4]/div/div/ng-view/div/div[1]/div[1]/div/div/div[2]"))
                  //  .Click();

               // firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

              //  firefox.FindElement(By.Id("label_for_services_call_number")).SendKeys("77777777");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);


                firefox.FindElement(By.Id("postcode")).SendKeys("3600");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                Thread.Sleep(4000);
                firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[1]/label")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                Thread.Sleep(4000);
                firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[3]/a")).Click();



                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                Thread.Sleep(4000);
                firefox.FindElement(By.Id("label_for_services_call_number")).SendKeys("77777777");
               // firefox.FindElement(By.CssSelector("span.control-indicator")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                firefox.FindElement(
                     By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label")).Click();


                firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
               // firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                
                firefox.FindElement(By.XPath("//div[@class='col-md-8']/div[3]/button")).Click();

                firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
                firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
                firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
                firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
               // firefox.FindElement(By.Id("delivery_postcode")).SendKeys("3600");
                firefox.FindElement(By.Id("label_for_email_address")).SendKeys("test.yhy@yopmail.com");
                firefox.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(
                    By.XPath(
                        "/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(By.XPath("//button[@type='button']")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(By.CssSelector("span.control-indicator")).Click();
                firefox.FindElement(By.XPath("//button[@type='button']")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(By.XPath("/html/body/div[3]/div[2]/div[7]/a")).Click();
                Thread.Sleep(3000);
            }
            finally { firefox.Quit(); }

        }


  
        

    }
}

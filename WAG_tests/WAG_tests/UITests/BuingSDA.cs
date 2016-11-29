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
    public class BuyingGoods
    {
        FirefoxDriver firefox;
        WebDriverWait wait;
        // ChromeDriver chrome;

        [Test()]
        public void BuingSDAWithoutServises()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));

            try
            {

                firefox.Navigate()
                    .GoToUrl("http://whiteaway.com/stoevsuger/gulvrenser/product/nilfisk-nilfisk-smart-green-28/");
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

                firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/section[2]/div/div[2]/button")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                firefox.FindElement(By.LinkText("Kurv")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                firefox.FindElement(By.LinkText("Gå til bestilling")).Click();

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                firefox.FindElement(By.XPath("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input")).Click();

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
               

                firefox.FindElement(
                     By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label")).Click();


                firefox.FindElement(By.Id("comment")).SendKeys("+drop+");

                firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
                firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
                firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
                firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
                firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
                firefox.FindElement(By.Id("delivery_postcode")).SendKeys("3600");
                firefox.FindElement(By.Id("label_for_email_address")).SendKeys("test.yhy@yopmail.com");

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/form/div[6]/button")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(
                    By.XPath(
                        "/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div/label/div/div[1]/div/div/div[1]/span"))
                    .Click();
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


        [Test()]
        public void BuingSDAoutOfStockWithOption()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));

            try
            {
                firefox.Navigate()
                    .GoToUrl("http://www.whiteaway.com/koekkenudstyr/blender/blender/product/kitchenaid-a-m-0-75l-krom/");

                firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/section[2]/div/div[2]/button")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                
                firefox.FindElement(By.LinkText("Kurv")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                firefox.FindElement(By.LinkText("Gå til bestilling")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                Thread.Sleep(3000);

                firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]/div[1]/label"))
                    .Click();

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                Thread.Sleep(3000);



                firefox.FindElement(
                    By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[3]/a")).Click();

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                Thread.Sleep(3000);
                firefox.FindElement(
                    By.XPath("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input")).Click();

                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);


//                firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[2]/div[1]/div[3]/a")).Click();


             //   firefox.FindElement(
              //      By.XPath(
             //           "//div[@id='content']/div/div/div/ng-view/div[2]/form/div/div/div/div/div[2]/div/div/div/label[3]/div/div/div/div/div/div[2]/div/b"))
              //      .Click();

                firefox.FindElement(
                     By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label")).Click();

                firefox.FindElement(By.Id("comment")).SendKeys("+drop+");

                firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
                firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
                firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
                firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
                firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
                firefox.FindElement(By.Id("delivery_postcode")).SendKeys("3600");
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

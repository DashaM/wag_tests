using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;


namespace WAG_tests
{

    [TestFixture()]

    public class TestBase
    {
        public static IWebDriver firefox;
        private Cookie myCookie = new Cookie("cof_checkout_process", "onepage");
      
      WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {

            firefox = WebDriverFactory.GetDriver(DesiredCapabilities.Firefox());



            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.Manage().Window.Maximize();
            firefox.Navigate().GoToUrl("http://whiteaway.com/");
        }





        // methods for all tests
        protected void Logout()
        {
            firefox.FindElement(By.LinkText("Log af")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }


        protected void Login(string login, string pass)
        {
            //firefox.FindElement(By.LinkText("Log ind")).Click();
            firefox.Navigate().GoToUrl("http://whiteaway.com/login/");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.Id("email_address")).SendKeys(login);
            firefox.FindElement(By.Id("password")).SendKeys(pass);
            firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }




        protected bool IsElementPresent(By by)
        {
            return firefox.FindElements(by).Count > 0;
        }


        protected bool LoggedInErrorDisplayed()
        {
            return IsElementPresent(By.LinkText("Fejl: E-mail -adressen eller kodeordet blev ikke genkendt."));
            
        }


        protected bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log af"));
        }


        protected bool IsEmptySearch()
        {
            return IsElementPresent(By.CssSelector("span.search__suggest-zero"));
        }

        protected bool IsProductsInBasket()
        {
            return IsElementPresent(By.CssSelector("span.search__suggest-zero"));
        }


        protected void AddProductToFavorits(string pageurl)
        {
            firefox.Navigate().GoToUrl(pageurl);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div[2]/div[2]/div[2]")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }


        protected void OpenFavoritesList(string productname)
        {
            
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.ClassName("favorites-widget__icon")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(35));
            Thread.Sleep(3000);
            Assert.That(firefox.FindElement(By.XPath("/html/body/div[3]/header/div/div[3]/div[2]/div/div[2]/div/div[4]")).Text, Is.StringContaining(productname)); 
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }



        protected void DeleteFavoriteProduct()
        {
            firefox.FindElement(By.ClassName("favorites-list__item__delete")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
          //  firefox.FindElement(By.ClassName("favorites-widget js-favorites-widget js-sniper-click js-click-track"));

           // Thread.Sleep(3000);
          //  Assert.IsFalse(firefox.FindElement(By.ClassName("favorites-widget js-favorites-widget js-sniper-click js-click-track active")).Enabled);
            
        }


        protected void InitializeSearch(string searchrequest)
        {
            firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).Clear();
            firefox.FindElement(By.CssSelector("input.search__input.js-search-field")).SendKeys(searchrequest);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }



        protected void IsSearchResultsPresent(string searchrequest)
        {
            firefox.FindElement(By.CssSelector("a.search__suggest__see-all")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
           // Assert.AreEqual(searchrequest, firefox.FindElement(By.XPath("/html/body/div[3]/div[4]/div[1]/div[1]/h1")).Text);
            Assert.GreaterOrEqual(firefox.FindElement(By.XPath("/html/body/div[3]/div[4]/div[1]/div[1]/h1")).Text, searchrequest);
        
        }



        protected void SearchPageNavigationNext(string url, string nextpagenumber)
        {
            firefox.Navigate()
                    .GoToUrl(url);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.LinkText(nextpagenumber)).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }



        protected void SearchPageNavigationPrevious(string nextpagenumber)
        {
            String ptr = firefox.Url;
            if (ptr.Contains("side" + nextpagenumber)) firefox.FindElement(By.CssSelector("a.pageResults.pageResultsPrev")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        protected void ClearBasket()
        {
            firefox.Navigate().GoToUrl("https://www.whiteaway.com/?action=empty_basket");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            
        }


        protected void AddProductWithoutBonustoBasket(string productpageurl)
        {
            firefox.Navigate().GoToUrl(productpageurl);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
            firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div/div[2]/div[1]")).Click();
            // firefox.FindElement(By.ClassName("vip__price-add-to-cart button button-forward button-lg js-add-to-cart js-click-track js-sniper-click")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
           // firefox.FindElement(By.LinkText("Kurv")).Click();
            firefox.Navigate().GoToUrl("https://www.whiteaway.com/cart_display/#/");
           
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(4000);
        }


        protected void AddProductWithBonustoBasket(string productpageurl)
        {
            firefox.Navigate().GoToUrl(productpageurl);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
            firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div[2]/div[2]/div[1]")).Click();
           // firefox.FindElement(By.ClassName("vip__price-cta-and-favorites-wrap")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.LinkText("Gå til kurv")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(4000);
        }




        protected void Add2ProducsToBasket(string productpageurl_1, string productpageurl_2)
    {
        firefox.Navigate()
                    .GoToUrl(productpageurl_1);
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
                firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div[2]/div[2]/div")).Click();
//                firefox.FindElement(By.ClassName("vip__price-cta-and-favorites-wrap")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                firefox.Navigate()
                   .GoToUrl(productpageurl_2);
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(3000);
              //  firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div[2]/div[2]/div")).Click();

                try
                {
                    firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div[2]/div[2]/div")).Click();
                    
                }
                catch (NoSuchElementException e)
                {
                    firefox.FindElement(By.XPath("/html/body/div[3]/div[3]/div[1]/section[3]/div/div[2]/div/button")).Click();
                }





            //  firefox.FindElement(By.ClassName("vip__price-cta-and-favorites-wrap")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                firefox.FindElement(By.LinkText("Gå til kurv")).Click();
                firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                Thread.Sleep(4000);
    }

        protected void CheckOutFlowStep0Delivery()
        {
            firefox.FindElement(By.Id("label_for_services_call_number")).Clear();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.Id("label_for_services_call_number")).SendKeys("77777777");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
          
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(4000);
            var iElement = firefox.FindElements(By.Id("comment"));
            for (int i = 0; i < iElement.Count; i = i + 1)
            {
                if (i!=0) //iElement[i].Displayed
                {
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
                else
                {
                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                    iElement = firefox.FindElements(By.CssSelector("span.control-indicator"));
                    var y = iElement.Count;
                   
                        if (y == 1)
                        {
                            firefox.FindElement(By.CssSelector("label.control")).Click();
                        }
                        else
                        {
                            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label/span")).Click();
                        }

                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
            } 


            


            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.XPath("//div[@class='col-md-8']/div[3]/button")).Click();
        }

        protected void CheckOutFlowStep0Delivery2MDA()
        {
            firefox.FindElement(By.Id("label_for_services_call_number")).Clear();
            firefox.FindElement(By.Id("label_for_services_call_number")).SendKeys("77777777");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(4000);

            var iElement = firefox.FindElements(By.Id("comment"));
            for (int i = 0; i < iElement.Count; i = i + 1)
            {
                if (iElement[i].Displayed)
                {
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
                else
                {
                    firefox.FindElement(
                     By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[3]/div[2]/label")).Click();
                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
            } 




            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[4]/button")).Click(); 
        }


        protected void CheckOutFlowStep0DeliveryMDAPlusSDA()
        {
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div/div/div[2]/div[2]/div/div/label[2]/div/div/div[1]/div/div")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            firefox.FindElement(By.Id("label_for_services_call_number")).Clear();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.Id("label_for_services_call_number")).SendKeys("77777777");

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(4000);

           var iElement = firefox.FindElements(By.Id("comment"));
            for (int i = 0; i < iElement.Count; i = i + 1)
            {
                if (iElement[i].Displayed)
                {
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
                else
                {
                    firefox.FindElement(
                        By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[3]/div[2]/label/span"))
                        .Click();
                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
            }


            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[4]/button")).Click();
        }


        protected void CheckOutFlowStep1Delivery()
        {
            firefox.FindElement(By.Id("delivery_telephone")).Clear();
            firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
            firefox.FindElement(By.Id("label_for_delivery_firstname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
            firefox.FindElement(By.Id("label_for_delivery_lastname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
            firefox.FindElement(By.Id("label_for_delivery_street_address")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
            firefox.FindElement(By.Id("label_for_email_address")).Clear();
            firefox.FindElement(By.Id("label_for_email_address")).SendKeys("test.yhy@yopmail.com");

            firefox.FindElement(By.XPath("//div[@class='col-md-8']/form/div[1]/div/div/div[2]/div[4]/div[1]/div/div/div/button")).Click();
            firefox.FindElement(By.XPath("//div[7]/div/div/div[3]/div/div[2]/button")).Click();
            firefox.FindElement(By.Id("postcode")).Clear();
            firefox.FindElement(By.Id("postcode")).SendKeys("3600");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            firefox.FindElement(By.CssSelector("a.btn")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.XPath("//div[@class='col-md-8']/div[3]/button")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/form/div[6]/button")).Click();
          //  firefox.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/form/div[6]/button")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }

        protected void CheckOutFlowStep1SDA()
        {

           // var iElement = firefox.FindElements(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label"));
           // firefox.FindElement(
                   //  By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label")).Click();
            var iElement = firefox.FindElements(By.Id("comment"));
            for (int i = 0; i < iElement.Count; i = i + 1)
            {
                if (iElement[i].Displayed)
                {
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");
                }
                else
                {
                   // firefox.FindElement(
                    //    By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label"))
                    //    .Click();

                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    Thread.Sleep(3000);
                    try
                    {
                        firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/form/div[1]/div[2]/div[2]/label")).Click();

                    }
                    catch (NoSuchElementException e)
                    {
                        firefox.FindElement(By.XPath("//div[@class='list-group']/div/label[2]/div/div/div[1]/div/input")).Click();
                    }

                    firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    firefox.FindElement(By.Id("comment")).Clear();
                    firefox.FindElement(By.Id("comment")).SendKeys("+drop+");


                }
            } 

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }


        protected void CheckOutFlowStep2SDA()
        {
            firefox.FindElement(By.Id("delivery_telephone")).Clear();
            firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
            firefox.FindElement(By.Id("label_for_delivery_firstname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
            firefox.FindElement(By.Id("label_for_delivery_lastname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
            firefox.FindElement(By.Id("label_for_delivery_street_address")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
            firefox.FindElement(By.Id("delivery_postcode")).Clear();
            firefox.FindElement(By.Id("delivery_postcode")).SendKeys("3600");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.Id("label_for_email_address")).Clear();
            firefox.FindElement(By.Id("label_for_email_address")).SendKeys("test.yhy@yopmail.com");

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/form/div[6]/button")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }


        protected void CheckOutFlowStep2MDA()
        {
            firefox.FindElement(By.Id("delivery_telephone")).Clear();
            firefox.FindElement(By.Id("delivery_telephone")).SendKeys("77777777");
            firefox.FindElement(By.Id("label_for_delivery_firstname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_firstname")).SendKeys("qwe");
            firefox.FindElement(By.Id("label_for_delivery_lastname")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_lastname")).SendKeys("ewq");
            firefox.FindElement(By.Id("label_for_delivery_street_address")).Clear();
            firefox.FindElement(By.Id("label_for_delivery_street_address")).SendKeys("qwe77");
            firefox.FindElement(By.Id("label_for_email_address")).Clear();
            firefox.FindElement(By.Id("label_for_email_address")).SendKeys("test.yhy@yopmail.com");
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/form/div[6]/button")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }




        protected void CheckOutFlowStep3PaymentMethod(string paymentxpath)
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.XPath(paymentxpath)).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);

            firefox.FindElement(By.XPath("//button[@type='button']")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }


        protected void CheckOutFlowLastStep()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
            firefox.FindElement(By.CssSelector("span.control-indicator")).Click();
            firefox.FindElement(By.XPath("//button[@type='button']")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Thread.Sleep(3000);
           
        }

        protected void FinalStep()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
//            Assert.AreEqual("Vi sender dig snarest en bestillingsbekræftelse på den mail du har indtastet nedenfor.\r\nVi glæder os til at hjælpe dig med dit køb.", firefox.FindElement(By.XPath("//div[@id='content']/div[2]/div[3]/p[2]")).Text);
            firefox.Navigate().GoToUrl("http://whiteaway.com/");
           // firefox.FindElement(By.XPath("/html/body/div[3]/header/div/a[1]/svg/use")).Click();
           // firefox.FindElement(By.LinkText("Til forsiden")).Click();
            Thread.Sleep(3000);
            
        }


        protected void StartCheckOutFlowFromBasketDeliveryonly()
        {
           // firefox.FindElement(By.XPath("/html/body/div[3]/div[4]/div/div/ng-view/div/div[1]/div[1]/div/div/div[2]")).Click();
            firefox.FindElement(By.LinkText("Gå til bestilling")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            Thread.Sleep(4000);

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
        }



        protected void StartCheckOutFlowFromBasket()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
            firefox.FindElement(By.LinkText("Gå til bestilling")).Click();
//            firefox.FindElement(By.ClassName("btn btn-forward btn-lg btn-block ng-binding ng-scope")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
        }


        protected void SelectServiceSDA(string servicexpath)
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            firefox.FindElement(By.XPath(servicexpath))
                   .Click();

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Thread.Sleep(3000);

            firefox.FindElement(
                By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[3]/a")).Click();

            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Thread.Sleep(3000);
        }



        protected void SelectDeliveryOptionSDA(string deliveryxpath)
        {
            Thread.Sleep(3000);
            firefox.FindElement(By.XPath(deliveryxpath)).Click();

             firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
             Thread.Sleep(3000);
        }


        protected void SelectServiceMDA(string postcode ,string servicexpath)
        {
            firefox.FindElement(By.Id("postcode")).Clear();
            firefox.FindElement(By.Id("postcode")).SendKeys(postcode);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            Thread.Sleep(4000);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            firefox.FindElement(By.XPath(servicexpath)).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(4000);
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[3]/a")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(4000);
        }


        protected void SelectServiceMDA(string postcode)
        {
            firefox.FindElement(By.Id("postcode")).Clear();
            firefox.FindElement(By.Id("postcode")).SendKeys(postcode);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            Thread.Sleep(4000);
            firefox.FindElement(By.XPath("/html/body/div[4]/div/div/div/ng-view/div[3]/div[1]/div[3]/a")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(4000); 
        }


        protected void ViabillMoveBackToShop()
        {
            Thread.Sleep(5000);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            firefox.FindElement(By.XPath("/html/body/app/div/layout/vbc-free/div/vbc-email/vbc-email-form/form/div/button[1]")).Click();
            firefox.FindElement(By.XPath("/html/body/app/vbc-cancel-modal/div/div/div[2]/button[2]")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

        }


        protected void MobilePayMoveBackToShop()
        {
            Thread.Sleep(5000);
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            firefox.FindElement(By.XPath("/html/body/div/header/p[2]/a")).Click();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

        }




        protected bool IsBackToStep()
        {
            return IsElementPresent(By.ClassName("alert-body"));
        }


        protected void IsDropCommentPresent()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            if (Equals("Kommentar\r\n+drop+",
                firefox.FindElement(By.CssSelector("div.checkout-panel-body > div.ng-binding.ng-scope")).Text))
            {
                Console.WriteLine("Drop comment displayed");
            }
            else
            {
                if (Equals("Kommentar\r\n+drop+",
                firefox.FindElement(By.CssSelector("div.checkout-panel-body > div.ng-binding.ng-scope")).Text))
                { Console.WriteLine("Drop comment displayed!!!"); }
            }

                //Assert.AreEqual("Kommentar\r\n+drop+", firefox.FindElement(By.CssSelector("div.checkout-panel-body > div.ng-binding.ng-scope")).Text);
        }



        protected void IsAltapayGatewayOpened()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Assert.AreEqual("Indtast dine kortoplysninger", firefox.FindElement(By.CssSelector("h2.wag-panel__header")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.logo")));
        }



        protected void ApplyFilteronSRP(string filterXpath, string filtervalueXpath)
        { 
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            firefox.FindElement(By.XPath(filterXpath)).Click();
            firefox.FindElement(By.XPath(filtervalueXpath)).Click();
        }


        protected void IsFilterApplied()
        {
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Assert.AreEqual(": 6", firefox.FindElement(By.XPath("/html/body/div[3]/div[4]/div[2]/div[2]/div[1]/div[1]/div/div[1]/div[2]/div[1]/div[4]/div/span")).Text);
        }



        protected void AddNewCofCookie()
        {
            firefox.Manage().Cookies.DeleteAllCookies();
           firefox.Manage().Cookies.AddCookie(myCookie);
        }
      



    }
}

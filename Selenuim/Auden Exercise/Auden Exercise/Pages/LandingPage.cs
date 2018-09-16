
namespace Auden_Exercise.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Auden_Exercise.PageElements;
    using Auden.Exercise.Webdriver.Webdriver;
    using Auden.Exercise.Common;

    public class LandingPage : LandingPageElements
    {
        private Idriver driver;
        private RegistrationPage registrationPage;
        private LoginPage loginPage;
        public LandingPage (Idriver driver)
        {
            this.driver = driver;
            this.registrationPage = new RegistrationPage(this.driver);
            this.loginPage = new LoginPage(this.driver);
        }

        public void NaviagetToLoginPage()
        {
            int attempts = 0;
            while (!this.driver.IsElementVisible(loginPage.TxtLoginPassword) && attempts < 8)
            {
                if (this.driver.IsElementVisible(loginPage.SignOutLink))
                {
                    this.driver.ClickAllVisible(loginPage.SignOutLink);
                    this.driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                }
                else
                {
                    this.driver.ClickAllVisible(loginPage.SignInLink);
                    this.driver.WaitForPageLoad(TimeSpan.FromSeconds(15));
                }

                System.Threading.Thread.Sleep(1000);
                attempts++;
            }

            this.driver.WaitForPageLoad(TimeSpan.FromSeconds(15));
            this.driver.WaitForElementVisible(loginPage.TxtLoginPassword, 3);
        }

        public void AddItemToBasket(string price)
        {

        }

        public void AssertUserIsOnLandingPage()
        {
            if (this.driver.PageTitle() != "My Store")
            {
                this.driver.Navigate(Constants.ApplicationUrl);
                this.driver.WaitForPageLoad(TimeSpan.FromMinutes(0.5));
                NUnit.Framework.Assert.True(this.driver.IsElementVisible(this.ProductsContainer));
            }
        }

        public string GetSpecificItemPrice(bool mostExpensive = false, bool cheapest = false)
        {
            string itemPrice = string.Empty;
            List<decimal> array = new List<decimal>();
            if (mostExpensive)
            {
               foreach(var e in this.driver.GetVisibleElements(this.ProductPrice()))
               {
                    array.Add(decimal.Parse(e.Text.Trim('$')));
               }

                itemPrice = array.Max().ToString();
            }
            else if (cheapest)
            {
                foreach (var e in this.driver.GetVisibleElements(this.ProductPrice()))
                {
                    array.Add(decimal.Parse(e.Text.Trim('$')));
                }

                itemPrice = array.Min().ToString();
            }

            return itemPrice;
        }

        public void SelectProductCategory(string category)
        {
            this.driver.ClickAllVisible(this.ProductCategory(category));
            this.driver.WaitForPageLoad(TimeSpan.FromSeconds(10));
        }

        public void SelectSpecificItemAndAddToBasket(string itemPrice)
        {
            this.driver.MoveToElement(this.ProductPrice(itemPrice));
            this.driver.WaitForPageLoad(TimeSpan.FromSeconds(20));
            this.driver.ClickAllVisible(this.BtnAddToBasket);
            this.driver.WaitForPageLoad(TimeSpan.FromMinutes(1));
            System.Threading.Thread.Sleep(2000);
            this.driver.ClickAllVisible(this.ContinueShoppingButton);
            System.Threading.Thread.Sleep(2000);
            this.driver.Browser().Navigate().Refresh();
            System.Threading.Thread.Sleep(2000);
            this.driver.WaitForPageLoad(TimeSpan.FromSeconds(15));
            this.AssertShoppingBasketIsNotEmpty();
            Console.Write("Shopping cart successfully added an item");
        }

        public void AssertShoppingBasketIsNotEmpty()
        {
            NUnit.Framework.Assert.True(this.driver.FindElementVisible(this.EmptyBasketItemCount) == null, "Expected to have at least 1 item in the basket but basket was empty!");
        }
    }
}

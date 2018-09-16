
namespace Auden.Exercise.Tests.Code_Bindings
{
    using System;
    using TechTalk.SpecFlow;
    using Auden.Exercise.Tests;

    [Binding]
    public class UISmokeTestsSteps : Hooks
    {
        private string itemPrice;

        [Given(@"user is on the site login page")]
        public void GivenUserIsOnTheSiteLoginPage()
        {
            this.LandingPage.AssertUserIsOnLandingPage();
            this.LandingPage.NaviagetToLoginPage();
        }

        [Given(@"Provides an email address under create new account form and clicks the create account button")]
        public void GivenProvidesAnEmailAddressEmailEmail_ComUnderCreateNewAccountFormAndClicksTheCreateAccountButton()
        {
            
            this.LoginPage.RequestNewUserRegistrationForm(this.UseEmailAddress);
        }


        [When(@"user successfully creates an account")]
        public void WhenUserSuccessfullyCreatesAnAccount()
        {
            this.RegistrationPage.CreateAnewAccount(this.UseEmailAddress);
        }
        
        [Then(@"the user should be redirected to registration form")]
        public void ThenTheUserShouldBeRedirectedToRegistrationForm()
        {
            this.RegistrationPage.AssertUserIsOnRegistrationPage();
        }
        
        [Then(@"user should be redirected to My account page")]
        public void ThenUserShouldBeRedirectedToMyAccountPage()
        {
            this.MyAccountPage.AssertUserIsOnMyAccountPage();
        }
        
        [Then(@"user should be able to logout and log back in with newly created credentials")]
        public void ThenUserShouldBeAbleToLogoutAndLogBackInWithNewlyCreatedCredentials()
        {
            this.LoginPage.Login(this.UseEmailAddress);
        }

        [When(@"user selects an item category as (.*) and chooses a product listed with (.*) price")]
        public void WhenUserSelectsAnItemCategoryAsDressAndChoosesAProductListedWithHighestPricePrice(string p0, string p1)
        {
            this.LandingPage.SelectProductCategory(p0);
            itemPrice = this.LandingPage.GetSpecificItemPrice(mostExpensive: p1.Contains("Highest"), cheapest: p1.Contains("Cheapest"));

        }

        [Then(@"user can now add selected item to basket")]
        public void ThenUserCanNowAddSelectedItemToBasket()
        {
            this.LandingPage.SelectSpecificItemAndAddToBasket(itemPrice);
        }

        [When(@"user logs out, and logs back in, item should still be in the basket")]
        public void WhenUserLogsOutAndLogsBackInItemShouldStillBeInTheBasket()
        {
            this.LoginPage.Login(this.UseEmailAddress);
            this.LandingPage.AssertShoppingBasketIsNotEmpty();


        }

    }
}

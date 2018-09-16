

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
    public class LoginPage : LoginPageElements
    {
        private Idriver driver;
        private RegistrationPage registrationPage;
        private CommonMethods commonMethods;
        public LoginPage(Idriver driver)
        {
            this.driver = driver;
            this.registrationPage = new RegistrationPage(this.driver);
            this.commonMethods = new CommonMethods();
        }

        public void Login(string emailAddress, bool loginIsMandatory = true)
        {
            if (!this.driver.IsElementVisible(this.TxtLoginPassword))
            {
                LandingPage landing = new LandingPage(this.driver);
                landing.NaviagetToLoginPage();
            }

            ////Don't login if we've already logged in
            if (loginIsMandatory)
            {
                ////Sign out first and log back in
                if (this.driver.IsElementVisible(this.SignOutLink))
                {
                    this.driver.ClickAllVisible(this.SignOutLink);
                    driver.WaitForElementVisible(this.SignInLink);
                }

                //// If login form is not visible
                if (!this.driver.IsElementVisible(this.TxtLoginEmail))
                {
                    this.driver.ClickAllVisible(this.SignInLink);
                    driver.WaitForElementVisible(this.TxtLoginEmail);
                }

                this.driver.Type(this.TxtLoginEmail, emailAddress);
                this.driver.Type(this.TxtLoginPassword, commonMethods.GetAppConfigPropertyValue("Password"));
                this.driver.Click(this.BtnLoginSubmission);
                this.driver.WaitForElementVisible(this.SignOutLink);
            }
        }

        public void RequestNewUserRegistrationForm(string emailAddress)
        {
            if (this.driver.IsElementVisible(this.TxtEmailCreate))
            {
                this.driver.Type(this.TxtEmailCreate, emailAddress);
                this.driver.Click(this.BtnCreateNewAccount);
                this.driver.WaitForElementVisible(registrationPage.TxtCustomerFirstname);
            }
        }
    }
}

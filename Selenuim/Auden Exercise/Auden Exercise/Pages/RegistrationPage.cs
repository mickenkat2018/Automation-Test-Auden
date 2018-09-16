
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

    public class RegistrationPage : LoginPageElements
    {
        public string email;
        private Idriver driver;
        private CommonMethods commonMethods;

        public RegistrationPage(Idriver driver)
        {
            this.driver = driver;
            this.commonMethods = new CommonMethods();
        }

        public void CreateAnewAccount(string emailAddress)
        {
            if (this.driver.IsElementVisible(this.TxtAddressFirstname))
            {
                LandingPage landing = new LandingPage(this.driver);
                landing.NaviagetToLoginPage();
                LoginPage loginPage = new LoginPage(this.driver);
                loginPage.RequestNewUserRegistrationForm(emailAddress);
                this.driver.WaitForElementVisible(this.TxtAddressFirstname);
            }

            //// The information being entered below is hardcorded for testing purposes, ideally it should
            /// be stored / read in a separate file, ideally spreadsheet or can be put into a class as properities/fields
            this.driver.ClickAllVisible(this.RdoGender);
            this.driver.Type(this.TxtCustomerFirstname, "Michael");
            this.driver.Type(this.TxtCustomerLastname, "Automation");
            this.driver.Type(this.TxtLoginPassword, commonMethods.GetAppConfigPropertyValue("Password"));
            this.driver.SelectFromDropDownList(this.DdlDays, "1", true);
            this.driver.SelectFromDropDownList(this.DdlMonths, "1", true);
            this.driver.SelectFromDropDownList(this.DdlYears, "2000", true);
            this.driver.Type(this.TxtAddressAddress1, "Wilmslow");
            this.driver.Type(this.TxtAddressCity, "Manchester");
            this.driver.SelectFromDropDownList(this.DdlState, "5", byIndex: true);
            this.driver.Type(this.TxtPostcode, "01234");
            this.driver.SelectFromDropDownList(this.DdlCountry, "1", byIndex: true);
            this.driver.Type(this.TxtMobilePhone, "01234567");
            this.driver.Type(this.TxtAlternativeAddress, "Same as provided above");
            this.driver.ClickAllVisible(this.BtnSubmitAccount);
            this.driver.WaitForPageLoad(TimeSpan.FromMinutes(1.5));
        }

        public void AssertUserIsOnRegistrationPage()
        {
            NUnit.Framework.Assert.True(this.driver.FindElementVisible(this.TxtAddressFirstname).Displayed);
        }
    }
}

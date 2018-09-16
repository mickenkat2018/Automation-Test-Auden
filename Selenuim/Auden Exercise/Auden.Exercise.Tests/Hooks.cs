
namespace Auden.Exercise.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using Auden.Exercise.Webdriver.Webdriver;
    using Auden_Exercise.Pages;
    using Auden.Exercise.Common;

    public class Hooks
    {
        /// <summary>
        /// 
        /// </summary>
        public Idriver Driver { get; set; }

        /// <summary>
        /// Login Page
        /// </summary>
        public LoginPage LoginPage { get; set; }

        /// <summary>
        /// Landing Page
        /// </summary>
        public LandingPage LandingPage { get; set; }

        /// <summary>
        /// Registration Page
        /// </summary>
        public RegistrationPage RegistrationPage { get; set; }

        public MyAccountPage MyAccountPage { get; set; }

        public CommonMethods CommonMethods { get; set; }

        public string UseEmailAddress { get; set; }
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new Driver();
            this.Driver.StartBrowser();
            this.RegistrationPage = new RegistrationPage(this.Driver);
            this.LandingPage = new LandingPage(this.Driver);
            this.LoginPage = new LoginPage(this.Driver);
            this.MyAccountPage = new MyAccountPage(this.Driver);
            this.CommonMethods = new CommonMethods();
            this.Driver.Navigate(this.CommonMethods.GetAppConfigPropertyValue(Common.Constants.ApplicationUrl));
            this.UseEmailAddress = CommonMethods.RandomString(9) + "@auden.com";
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.Driver.StopBrowser();
        }
    }
}

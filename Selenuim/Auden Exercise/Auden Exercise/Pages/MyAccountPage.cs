
namespace Auden_Exercise.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Auden_Exercise.PageElements;
    using Auden.Exercise.Webdriver.Webdriver;
    using NUnit.Framework;

    public class MyAccountPage : MyAccountPageElements
    {
        private Idriver driver;

        public MyAccountPage(Idriver driver)
        {
            this.driver = driver;
        }

        public void AssertUserIsOnMyAccountPage()
        {
            //// Ideally, a screen shot would be taken here and saved for logging, if condition is false
            Assert.True(this.driver.IsElementVisible(this.OrderHistryTab), "Expected to be on landing page but wasn't");
        }
    }
}

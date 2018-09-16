

namespace Auden.Exercise.Webdriver.Webdriver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using NUnit.Framework;

    public interface Idriver
    {
        /// <summary>
        /// Current Driver Instance
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver Browser();

        void StopBrowser();

        /// <summary>
        /// Starts Browser
        /// </summary>
        /// <param name="browser"></param>
        void StartBrowser(string browser = "chrome");

        /// <summary>
        /// Clicks Element
        /// </summary>
        /// <param name="element"></param>
        void Click(string locator);

        /// <summary>
        /// Clicks All Visible
        /// </summary>
        /// <param name="locator"></param>
        void ClickAllVisible(string locator);

        /// <summary>
        /// Waits For Page load
        /// </summary>
        /// <param name="span"></param>
        void WaitForPageLoad(TimeSpan span);

        /// <summary>
        /// Navigates to spacified Url
        /// </summary>
        /// <param name="url"></param>
        void Navigate(string url);

        /// <summary>
        /// finds a visible element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        IWebElement FindElementVisible(string locator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>True if element is visible on UI else false</returns>
        bool IsElementVisible(string locator);

        /// <summary>
        /// Selects from drop down list, selects by text by default
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="item"></param>
        /// <param name="byValue"></param>
        /// <param name="byIndex"></param>
        void SelectFromDropDownList(string locator, string item, bool byValue= false, bool byIndex = false);

        /// <summary>
        /// waits until specified element is visible
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeInSeconds"></param>
        void WaitForElementVisible(string locator, double timeInSeconds = 60);

        /// <summary>
        /// Types into qn element
        /// </summary>
        /// <param name="locator"></param>
        void Type(string locator, string textToSend);

        string PageTitle();

        IList<IWebElement> GetVisibleElements(string locator);

        void MoveToElement(string locator);

        bool IsTesxtPresent(string text);
    }
}


namespace Auden.Exercise.Webdriver.Webdriver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Support.UI;
    using NUnit.Framework;

    public class Driver : Idriver
    {
        private IWebDriver _browser;

        /// <summary>
        /// Current Browser
        /// </summary>
        /// <returns></returns>
        public IWebDriver Browser()
        {
            return this._browser;
        }

        /// <summary>
        /// Starts Browser
        /// </summary>
        /// <param name="browser"></param>
        public void StartBrowser(string browser = "chrome")
        {
            switch (browser)
            {
                case "firefox":
                    _browser = new FirefoxDriver();
                    _browser.Manage().Window.Maximize();
                    break;
                case "IE":
                    _browser = new InternetExplorerDriver();
                    _browser.Manage().Window.Maximize();
                    break;
                default:
                    _browser = new ChromeDriver();
                    _browser.Manage().Window.Maximize();
                    break;
            }
        }

        /// <summary>
        /// Clicks element on the UI
        /// </summary>
        /// <param name="locator"></param>
        public void Click(string locator)
        {
            if (string.IsNullOrEmpty(locator))
            {
                throw new Exception("Element can not be null");
            }

            try
            {
                this.FindElementVisible(locator).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ClickAllVisible(string locator)
        {
            try
            {
                foreach (IWebElement e in this.GetAllWebElements(locator))
                {
                    if (e.Displayed)
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e )
            {
                Console.Write(e.Message);
            }
        }
        /// <summary>
        /// Finds element displayed on the page
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public IWebElement FindElementVisible(string locator)
        {
            try
            {
                if (this.FindElement(By.Id(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.Id(locator)))
                    {
                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
                else if (this.FindElement(By.ClassName(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.ClassName(locator)))
                    {
                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
                else if (this.FindElement(By.CssSelector(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.CssSelector(locator)))
                    {
                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
                else if (this.FindElement(By.LinkText(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.LinkText(locator)))
                    {
                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
                else if (this.FindElement(By.Name(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.Name(locator)))
                    {
                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
                else if (this.FindElement(By.XPath(locator)) != null)
                {
                    foreach (IWebElement el in this._browser.FindElements(By.XPath(locator)))
                    {
                        if(el.TagName == "select" && el.Enabled)
                        {
                            return el;
                        }

                        if (el.Displayed)
                        {
                            return el;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return null;
        }

        private ICollection<IWebElement> GetAllWebElements(string locator)
        {
            ICollection<IWebElement> el = null;
            if (this.FindElement(By.Id(locator)) != null)
            {
                el = this.Browser().FindElements(By.Id(locator));
            }
            else if (this.FindElement(By.Name(locator)) != null)
            {
                el = this.Browser().FindElements(By.Name(locator));
            }
            else if (this.FindElement(By.LinkText(locator)) != null)
            {
                el = this.Browser().FindElements(By.LinkText(locator));
            }
            else if (this.FindElement(By.TagName(locator)) != null)
            {
                el = this.Browser().FindElements(By.TagName(locator));
            }
            else if (this.FindElement(By.XPath(locator)) != null)
            {
                el = this.Browser().FindElements(By.XPath(locator));
            }
            else if (this.FindElement(By.ClassName(locator)) != null)
            {
                el = this.Browser().FindElements(By.ClassName(locator));
            }

            return el;
        }

        public IList<IWebElement> GetVisibleElements(string locator)
        {
            IList<IWebElement> elements = new List<IWebElement>();
            foreach(var e in this.GetAllWebElements(locator))
            {
                if (e.Displayed)
                {
                    elements.Add(e);
                }
            }

            return elements;
        }

        /// <summary>
        /// Moves and hovers to element
        /// </summary>
        /// <param name="locator"></param>
        public void MoveToElement(string locator)
        {
            Actions action = new Actions(this._browser);
            action.MoveToElement(this.FindElementVisible(locator));
            action.Perform();
        }

        /// <summary>
        /// Waits until Dom is ready
        /// </summary>
        /// <param name="timespan"></param>
        public void WaitForPageLoad(TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this._browser, timespan);
            wait.Until(a => ((IJavaScriptExecutor)this._browser).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Navigates to specific url
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {
            this._browser.Navigate().GoToUrl(url);
            this.WaitForPageLoad(TimeSpan.FromMinutes(1));
        }

        public bool IsElementVisible(string locator)
        {
            if (this.FindElementVisible(locator) != null)
            {
                return true;
            }

            return false;
        }

        public void SelectFromDropDownList(string locator, string item, bool byValue = false, bool byIndex = false)
        {
            ///for some reason the drop down for this website are not displayed, however, they are enabled
            ///the below GetAllWebElements GETS all elements that match locator provided and retuns a list
            ///So I then take the first element in the list, this is just a work-around for this sites dropdown list interactions
            
            var ddl = this.GetAllWebElements(locator);
            if (ddl == null)
            {
                throw new Exception("Drop down list " + locator + " Not found at current page");
            }
            var selectElement = new SelectElement(ddl.FirstOrDefault());
            if (byValue)
            {
                selectElement.SelectByValue(item);
            }
            else if (byIndex)
            {
                selectElement.SelectByIndex(int.Parse(item));
            }
            else
            {
                selectElement.SelectByText(item);
            }
        }

        /// <summary>
        /// Waits until element is visible, Default Time = 60 sec
        /// </summary>
        /// <param name="time"></param>
        public void WaitForElementVisible(string locator, double timeInSeconds = 60)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks);
            double totalTime = this.ClockTime(ts);
            while (this.FindElementVisible(locator) == null && totalTime <= timeInSeconds)
            {
                totalTime = Convert.ToInt32(this.ClockTime(ts));
                if (totalTime >= timeInSeconds)
                {
                     Assert.Fail("Failed to find locator with locator expression " + locator + " after " + totalTime + " seconds");
                }
            }
        }

        public void Type(string locator, string textToSend)
        {
            var element = this.FindElementVisible(locator);
            if (element != null)
            {
                element.Clear();
                element.SendKeys(textToSend);
            }
            else
            {
                throw new Exception("Element " + locator + " is not found");
            }
        }

        public void StopBrowser()
        {
            this.Browser().Dispose();
        }

        public string PageTitle()
        {
            return this.Browser().Title;
        }

        public bool IsTesxtPresent(string text)
        {
            if (this.Browser().PageSource.Contains(text))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private IWebElement FindElement(By by)
        {
            _browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                return _browser.FindElement(by);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private double ClockTime(TimeSpan timeSpan)
        {
            var ts2 = new TimeSpan(DateTime.Now.Ticks);
            var ts3 = timeSpan - ts2;
            return Math.Abs(ts3.TotalSeconds);
        }
    }
}

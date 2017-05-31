using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDDfy.Selenium.Test.Selenium
{
    public abstract class SeleniumBasePage : SeleniumElementContainer
    {
        protected readonly string WebsiteBaseUrl;

        protected SeleniumBasePage(IWebDriver driver, string websiteBaseUrl)
            : base(driver)
        {
            if (websiteBaseUrl == null) throw new ArgumentNullException(nameof(websiteBaseUrl));

            WebsiteBaseUrl = websiteBaseUrl;
        }

        protected abstract string Url { get; }

        public SeleniumBasePage Open()
        {
            Driver.Navigate().GoToUrl(Url);

            return WaitUntilOpen();
        }

        public void ShouldContainUrl(string url)
        {
            try
            {
                var timeout = TimeSpan.FromSeconds(10);

                var wait = new WebDriverWait(Driver, timeout);

                wait.Until(ExpectedConditions.UrlContains(url));
            }
            catch (TimeoutException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.
                    Assert.Fail($"\nExpected to contain URL: {Url}\nActual URL: {Driver.Url}");
            }
        }

        public void ShouldBeOpen()
        {
            try
            {
                WaitUntilOpen();
            }
            catch (TimeoutException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.
                    Assert.Fail($"\nExpected URL: {Url}\nActual URL: {Driver.Url}");
            }
        }

        public SeleniumBasePage WaitUntilOpen()
        {
            var timeout = TimeSpan.FromSeconds(5);

            var wait = new WebDriverWait(Driver, timeout);

            // TODO: This doesn't seem to work
            var result = wait.Until(driver =>
            {
                var urlMatches = ExpectedConditions.UrlMatches(Url);
                return urlMatches;
            });

            return this;
        }
    }
}

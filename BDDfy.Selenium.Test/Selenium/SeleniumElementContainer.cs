using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDDfy.Selenium.Test.Selenium
{
    public abstract class SeleniumElementContainer
    {
        protected readonly IWebDriver Driver;
        protected readonly string DataAutomationTag = "data-reactid";
        protected readonly string TypeTag = "type";
        protected readonly string NameTag = "name";
        protected readonly string ClassTag = "class";

        protected SeleniumElementContainer(IWebDriver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            Driver = driver;
        }

        protected IWebElement WaitForElement(string tagName, string tagValue, int timeout = 5,
            Func<By, Func<IWebDriver, IWebElement>> waitCondition = null)
        {
            return FindElementByXPath(GetXPath(tagName, tagValue), timeout, waitCondition);
        }

        protected IWebElement WaitForClickableElement(string tagName, string tagValue)
        {
            return WaitForElement(tagName, tagValue, 5, ExpectedConditions.ElementToBeClickable);
        }
        
        protected bool WaitForElementToDisappear(string tagName, string tagValue, int waitTimeout = 5)
        {
            var xPath = GetXPath(tagName, tagValue);
            var locator = By.XPath(xPath);

            return new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeout))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected static string GetXPath(string tagName, string tagValue)
        {
            return $@"//*[@{tagName}='{tagValue}']";
        }
        
        protected IWebElement FindElementByCss(string css, int? waitTimeout = 5,
            Func<By, Func<IWebDriver, IWebElement>> waitCondition = null)
        {
            var locator = By.CssSelector(css);

            if (waitTimeout.HasValue)
            {
                if (waitCondition == null)
                    waitCondition = ExpectedConditions.ElementExists;

                return new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeout.Value))
                    .Until(waitCondition(locator));
            }

            return Driver.FindElement(locator);
        }

        protected IWebElement FindElementByXPath(string xPath, int? waitTimeout = null,
            Func<By, Func<IWebDriver, IWebElement>> waitCondition = null)
        {
            var locator = By.XPath(xPath);

            if (waitTimeout.HasValue)
            {
                if (waitCondition == null)
                    waitCondition = ExpectedConditions.ElementExists;

                return new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeout.Value))
                    .Until(waitCondition(locator));
            }

            return Driver.FindElement(locator);
        }
    }
}

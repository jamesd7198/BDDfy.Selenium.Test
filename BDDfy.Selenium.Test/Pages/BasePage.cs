using BDDfy.Selenium.Test.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BDDfy.Selenium.Test.Pages
{
    public abstract class BasePage : SeleniumBasePage
    {
        protected override string Url { get; }

        protected IWebElement DonateLink => FindElementByCss("div.right-side ul li");

        protected BasePage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url;
        }
        
        public DonationPage DonateOnceFromDropdown()
        {
            var element = DonateLink;
            
            var actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();

            element.FindElement(By.CssSelector("ul.dropdown li a")).Click();

            return new DonationPage(Driver, WebsiteBaseUrl);
        }

        public TheSpringPage DonateMonthlyFromDropdown()
        {
            var element = DonateLink;

            var actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();

            element.FindElement(By.CssSelector("ul.dropdown li:nth-of-type(2) a")).Click();

            return new TheSpringPage(Driver, WebsiteBaseUrl);
        }

        public SponsorCommunityPage SponsorCommunityFromDropdown()
        {
            var element = DonateLink;

            var actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();

            element.FindElement(By.CssSelector("ul.dropdown li:nth-of-type(3) a")).Click();

            return new SponsorCommunityPage(Driver, WebsiteBaseUrl);
        }
    }
}

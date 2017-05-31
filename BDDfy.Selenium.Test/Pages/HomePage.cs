using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class HomePage : BasePage
    {
        protected override string Url { get; }

        public HomePage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url;
        }
    }
}

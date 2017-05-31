using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class CountryInfoPage : BasePage
    {
        protected override string Url { get; }

        public CountryInfoPage(IWebDriver driver, string url, string country)
            : base(driver, url)
        {
            Url = $"{url}{TestConfig.CountryInfoPage}{country}/";
        }
    }
}

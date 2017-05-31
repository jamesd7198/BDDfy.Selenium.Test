using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class TheSpringPage : BasePage
    {
        protected override string Url { get; }

        public TheSpringPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.TheSpringPage;
        }
    }
}

using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class VolunteerPage : BasePage
    {
        protected override string Url { get; }

        public VolunteerPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.VolunteerPage;
        }
    }
}

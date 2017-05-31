using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class ProjectsPage : BasePage
    {
        protected override string Url { get; }

        public ProjectsPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.ProjectsPage;
        }

        public SolutionsPage ViewSolutions()
        {
            FindElementByCss("div.project-section-links a:nth-of-type(2)")
                .Click();

            return new SolutionsPage(Driver, TestConfig.WebsiteBaseUrl);
        }

        public CountryInfoPage ViewCountryInfo(string country)
        {
            FindElementByCss($"a.dot[href$='{country}/']")
                .Click();

            return new CountryInfoPage(Driver, TestConfig.WebsiteBaseUrl, country);
        }
    }
}

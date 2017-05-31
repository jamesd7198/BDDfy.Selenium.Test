using BDDfy.Selenium.Test.Pages;
using BDDfy.Selenium.Test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace BDDfy.Selenium.Test.Tests
{
    [TestClass]
    public class ProjectsTests
    {
        ChromeBrowser _browser;
        ProjectsPage _projectsPage;
        CountryInfoPage _countryInfoPage;

        string Country { get; set; }
        string Url { get; set; }

        readonly ExampleTable _exampleTable = new ExampleTable("Country", "Url")
        {
            { "haiti", "/countries/haiti" },
            { "bolivia", "/countries/bolivia" },
            { "cambodia", "/countries/cambodia" }
        };

        [TestMethod]
        public void VerifyMapLinksWork()
        {
            this.Given(test => GivenBrowserOpenOnProjectsPage())
                .When(test => WhenClickingMapMarker(Country))
                .Then(test => ThenItShouldNavigateToTheCountryInfoPage(Url))
                .WithExamples(_exampleTable)
                .TearDownWith(test => TearDown())
                .BDDfy();
        }

        void GivenBrowserOpenOnProjectsPage()
        {
            _browser = new ChromeBrowser();
            _browser.Start();

            _projectsPage = SeleniumPageFactory.CreatePage<ProjectsPage>();
            _projectsPage.Open();
        }

        void WhenClickingMapMarker(string country)
        {
            _countryInfoPage = _projectsPage.ViewCountryInfo(country);
        }

        void ThenItShouldNavigateToTheCountryInfoPage(string url)
        {
            _countryInfoPage.ShouldContainUrl(url);
        }

        void TearDown()
        {
            _browser.Stop();
        }
    }
}

using BDDfy.Selenium.Test.Pages;
using BDDfy.Selenium.Test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace BDDfy.Selenium.Test.Tests
{
    [TestClass]
    public class ShouldNavigateToDonationPageFromDonateDropdown : SeleniumBaseTest<HomePage>
    {
        HomePage _homePage;
        DonationPage _donationPage;

        [TestMethod]
        public void VerifyBrowserOnDonationPage()
        {
            this.Given(test => GivenBrowserOpenOnHomePage())
                .When(test => WhenClickingDonateOnceFromDropdown())
                .Then(test => ThenItShouldNavigateToGeneralDonationPage())
                .BDDfy();
        }

        void GivenBrowserOpenOnHomePage()
        {
            _homePage = PageUnderTest;
        }

        void WhenClickingDonateOnceFromDropdown()
        {
            _donationPage = _homePage.DonateOnceFromDropdown();
        }

        void ThenItShouldNavigateToGeneralDonationPage()
        {
            _donationPage.ShouldBeOpen();
        }
    }

    [TestClass]
    public class ShouldNavigateToTheSpringPageFromDonateDropdown : SeleniumBaseTest<HomePage>
    {
        HomePage _homePage;
        TheSpringPage _springPage;

        [TestMethod]
        public void VerifyBrowserOnTheSpringPage()
        {
            this.Given(test => GivenBrowserOpenOnHomePage())
                .When(test => WhenClickingDonateMonthlyFromDropdown())
                .Then(test => ThenItShouldNavigateToTheSpringPage())
                .BDDfy();
        }

        void GivenBrowserOpenOnHomePage()
        {
            _homePage = PageUnderTest;
        }

        void WhenClickingDonateMonthlyFromDropdown()
        {
            _springPage = _homePage.DonateMonthlyFromDropdown();
        }

        void ThenItShouldNavigateToTheSpringPage()
        {
            _springPage.ShouldBeOpen();
        }
    }

    [TestClass]
    public class ShouldNavigateToSponsorCommunityPageFromDonateDropdown : SeleniumBaseTest<HomePage>
    {
        /*This method just lets BDDfy use reflection to get the steps from the method names. The names have to follow a convention.
         * 
           Here is the complete list of the out of the box conventions. The method name:
            * ending with "Context" is considered as a setup method (not reported).
            * "Setup" is considered as as setup method (not reported).
            * starting with "Given" is considered as a setup method (reported).
            * starting with "AndGiven" is considered as a setup method that runs after Context, Setup and Given steps (reported).
            * starting with "When" is considered as a transition method (reported).
            * starting with "AndWhen" is considered as a transition method that runs after When steps (reported).
            * starting with "Then" is considered as an asserting method (reported).
            * starting with "And" is considered as an asserting method (reported).
            * starting with "TearDown" is considered as a finally method which is run after all the other steps (not reported).
        */
          
        HomePage _homePage;
        SponsorCommunityPage _sponsorCommunityPage;

        [TestMethod]
        public void VerifyBrowserOnSponsorCommunityPage()
        {
            this.BDDfy();
        }

        void GivenBrowserOpenOnHomePage()
        {
            _homePage = PageUnderTest;
        }

        void WhenClickingDonateMonthlyFromDropdown()
        {
            _sponsorCommunityPage = _homePage.SponsorCommunityFromDropdown();
        }

        void ThenItShouldNavigateToTheSpringPage()
        {
            _sponsorCommunityPage.ShouldBeOpen();
        }
    }

    [TestClass]
    public class ShouldNavigateToSolutionsPage : SeleniumBaseTest<ProjectsPage>
    {
        ProjectsPage _projectsPage;
        SolutionsPage _solutionsPage;

        [TestMethod]
        public void VerifyBrowserOnSolutionsPage()
        {
            this.BDDfy();
        }

        void GivenBrowserOpenOnProjectsPage()
        {
            _projectsPage = PageUnderTest;
        }

        [IgnoreStep]
        void WhenClickingTheSolutionsLink()
        {
            _solutionsPage = _projectsPage.ViewSolutions();
        }

        [When("When clicking the solutions link")]
        void Foobar()
        {
            _solutionsPage = _projectsPage.ViewSolutions();
        }

        [Then("Then it should navigate to solutions page")]
        void Foomanchu()
        {
            _solutionsPage.ShouldBeOpen();
        }
    }
}

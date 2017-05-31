using BDDfy.Selenium.Test.Pages;
using BDDfy.Selenium.Test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace BDDfy.Selenium.Test.Tests
{
    [TestClass]
    [Story(
        AsA = "potential donor",
        IWant = "to see what solutions have been implemented",
        SoThat = "I know donations are being used properly")]
    public class ShouldBeAbleToViewImplementedSolutions : SeleniumBaseTest<SolutionsPage>
    {
        SolutionsPage _solutionsPage;

        [TestMethod]
        public void VerifyGravityFedSystemsDisplay()
        {
            this.Given(test => test.GivenBrowserOnSolutionsPage())
                .When(test => test.WhenClickingGravityFedSystems())
                .Then(test => ThenPhotosOfImplementedSystemsShouldBeDisplayed())
                .BDDfy<ShouldBeAbleToViewImplementedSolutions>();
        }

        [TestMethod]
        public void VerifyWaterPurificationSystemsDisplay()
        {
            this.Given(test => test.GivenBrowserOnSolutionsPage())
                .When(test => test.WhenClickingWaterPurificationSystems())
                .Then(test => ThenPhotosOfImplementedSystemsShouldBeDisplayed())
                .BDDfy<ShouldBeAbleToViewImplementedSolutions>();
        }

        void GivenBrowserOnSolutionsPage()
        {
            _solutionsPage = PageUnderTest;
        }

        void WhenClickingGravityFedSystems()
        {
            _solutionsPage.ViewGravityFedSystems();
        }

        void WhenClickingWaterPurificationSystems()
        {
            _solutionsPage.ViewWaterPurificationSystems();
        }

        void ThenPhotosOfImplementedSystemsShouldBeDisplayed()
        {
            _solutionsPage.ShouldBeAbleToSeeImages();
        }
    }
}

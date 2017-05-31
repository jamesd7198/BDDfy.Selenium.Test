using BDDfy.Selenium.Test.Pages;
using BDDfy.Selenium.Test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace BDDfy.Selenium.Test.Tests
{
    [TestClass]
    [Story(
         Title = "Adding feature for Lenexa residents to volunteer",
         AsA = "resident of Lenexa, KS",
         IWant = "to visit the Lenexa volunteers page",
         SoThat = "I can sign up to be a volunteer")]
    public class ShouldBeAbleToVolunteerInLenexa : SeleniumBaseTest<VolunteerPage>
    {
        VolunteerPage _volunteerPage;

        [TestMethod]
        public void VerifyTheVolunteerInLenexaLinkWasAdded()
        {
            this.Given(test => GivenBrowserOnVolunteerPage())
                .Then(test => ThenItShouldHaveVolunteerInLenexaLinkDisplayed())
                .BDDfy<ShouldBeAbleToVolunteerInLenexa>();
        }

        public void GivenBrowserOnVolunteerPage()
        {
            _volunteerPage = PageUnderTest;
        }

        public void ThenItShouldHaveVolunteerInLenexaLinkDisplayed()
        {
            Assert.Fail("Obviously fake check. They operate out of NYC.");
        }
    }
}

using BDDfy.Selenium.Test.Pages;
using BDDfy.Selenium.Test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace BDDfy.Selenium.Test.Tests
{
    [TestClass]
    public class ShouldBeAbleToDoOneTimeDonation : SeleniumBaseTest<DonationPage>
    {
        DonationPage _donationPage;
        PaymentModal _modal;

        [TestMethod]
        public void VerifyOneTimeDonation()
        {
            this.Given(test => test.GivenBrowserOpenOnDonationPage())
                .When(test => test.WhenDonating100DollarsWithCreditCard())
                .Then(test => test.ThenItShouldNavigateToPaymentConfirmationPage())
                .BDDfy();
        }

        void GivenBrowserOpenOnDonationPage()
        {
            _donationPage = PageUnderTest;
        }

        void WhenDonating100DollarsWithCreditCard()
        {
            _modal = _donationPage.EnterDonationAmount("100")
                .DonateWithCreditCard();
            
            //We're actually cancelling out back to donation page so we don't have to make a payment here. I'd expect this to actually redirect to
            //some sort of payment confirmation.
            _donationPage = _modal.EnterEmail("fake@fakemail.com")
                .EnterName("Fakename")
                .EnterStreet("123 Fake St.")
                .EnterCity("Faketown")
                .EnterZipCode("66212")
                .SubmitCardholderInfo()
                .EnterCardNumber("1234123412341234")
                .EnterExpiration("0120")
                .EnterCvcCode("123")
                .SubmitCardInfo();
        }

        void ThenItShouldNavigateToPaymentConfirmationPage()
        {
            //This is a bogus check because we're not actually making a payment to test this. Instead of continuing with the payment, we X'd out.
            //I'd expect to be redirected to a payment received page after making a payment, or some sort of notification of successful payment.
            _donationPage.ShouldBeOpen();
        }
    }
}

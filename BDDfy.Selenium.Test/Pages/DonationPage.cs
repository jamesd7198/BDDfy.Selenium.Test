using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class DonationPage : BasePage
    {
        protected override string Url { get; }

        public DonationPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.DonationPage;
        }

        public DonationPage ToggleGiveOnce()
        {
            WaitForClickableElement(DataAutomationTag, "26")
                .Click();

            return this;
        }

        public DonationPage ToggleGiveMonthly()
        {
            WaitForClickableElement(DataAutomationTag, "27")
                .Click();

            return this;
        }

        public DonationPage EnterDonationAmount(string amount)
        {
            var element = WaitForElement(DataAutomationTag, "14");

            element.Clear();
            element.SendKeys(amount);

            WaitForClickableElement(DataAutomationTag, "23")
                .Click();

            return this;
        }

        public PaymentModal DonateWithCreditCard()
        {
            FindElementByCss("button.payment.stripe-donate-button")
                .Click();

            WaitForElement(ClassTag, "stripe_checkout_app");
            Driver.SwitchTo().Frame("stripe_checkout_app");

            return new PaymentModal(Driver).WaitUntilOpen();
        }
    }
}

using System;
using BDDfy.Selenium.Test.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDDfy.Selenium.Test.Pages
{
    public class PaymentModal : SeleniumElementContainer
    {
        protected readonly string PlaceholderTag = "placeholder";
        
        public PaymentModal(IWebDriver driver)
            : base(driver)
        { }

        public PaymentModal EnterEmail(string email)
        {
            WaitForElement(TypeTag, "email")
                .SendKeys(email);

            return this;
        }

        public PaymentModal EnterName(string name)
        {
            WaitForElement(PlaceholderTag, "Name")
                .SendKeys(name);

            return this;
        }

        public PaymentModal EnterStreet(string street)
        {
            WaitForElement(PlaceholderTag, "Street")
                .SendKeys(street);

            return this;
        }

        public PaymentModal EnterCity(string city)
        {
            WaitForElement(PlaceholderTag, "City")
                .SendKeys(city);

            return this;
        }

        public PaymentModal EnterZipCode(string zip)
        {
            WaitForElement(TypeTag, "tel")
                .SendKeys(zip);

            return this;
        }

        public PaymentModal SubmitCardholderInfo()
        {
            FindElementByCss("div.Section-button button")
                .Click();

            return this;
        }

        public PaymentModal EnterCardNumber(string number)
        {
            WaitForElement(TypeTag, "tel")
                .SendKeys(number);

            return this;
        }

        public PaymentModal EnterExpiration(string expiration)
        {
            FindElementByCss("input[placeholder='MM / YY'")
                .SendKeys(expiration);

            return this;
        }

        public PaymentModal EnterCvcCode(string cvc)
        {
            FindElementByCss("input[placeholder='CVC'")
                .SendKeys(cvc);

            return this;
        }

        public DonationPage SubmitCardInfo()
        {
            FindElementByCss("input[placeholder='CVC'")
                .Click();

            //We're actually cancelling out back to donation page so we don't have to make a payment here. I'd expect this to actually redirect to
            //some sort of payment confirmation.
            WaitForElementToDisappear(ClassTag, "stripe_checkout_app");
            Driver.SwitchTo().DefaultContent();

            return new DonationPage(Driver, TestConfig.WebsiteBaseUrl);
        }

        public PaymentModal WaitUntilOpen()
        {
            var timeout = TimeSpan.FromSeconds(5);

            var wait = new WebDriverWait(Driver, timeout);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.Section-button button")));

            return this;
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class SolutionsPage : BasePage
    {
        protected override string Url { get; }

        public SolutionsPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.SolutionsPage;
        }

        public SolutionsPage ViewGravityFedSystems()
        {
            FindElementByCss("i.cw-icon-gravity-fed-system")
                .Click();
            
            return this;
        }

        public SolutionsPage ViewWaterPurificationSystems()
        {
            FindElementByCss("i.cw-icon-filtration-system")
                .Click();

            return this;
        }

        public SolutionsPage ViewNextImage()
        {
            FindElementByCss("a.fancybox-next")
                .Click();

            return this;
        }

        public void ShouldBeAbleToSeeImages()
        {
            var displayed = FindElementByCss("img.fancybox-image").Displayed;

            Assert.IsTrue(displayed, "Image was not displayed.");
        }
    }
}

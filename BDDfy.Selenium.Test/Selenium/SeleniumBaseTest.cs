using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace BDDfy.Selenium.Test.Selenium
{
    [TestClass]
    public class SeleniumBaseTest<TPageUnderTest>
        where TPageUnderTest : SeleniumBasePage
    {
        protected ChromeBrowser Browser;
        protected TPageUnderTest PageUnderTest;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Browser = new ChromeBrowser();

            Browser.Start();

            PageUnderTest = SeleniumPageFactory.CreatePage<TPageUnderTest>();
            PageUnderTest.Open();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                TakeScreenshot($"{TestContext.TestResultsDirectory}/{TestContext.TestName}_{DateTime.Now.ToFileTime()}");
            }
            
            Browser.Stop();
        }

        protected static void TakeScreenshot(string filename)
        {
            var ss = ChromeBrowser.Driver.TakeScreenshot();

            ss.SaveAsFile($"{filename}.jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}

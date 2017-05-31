using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BDDfy.Selenium.Test.Pages
{
    public class SponsorCommunityPage : BasePage
    {
        protected override string Url { get; }

        public SponsorCommunityPage(IWebDriver driver, string url)
            : base(driver, url)
        {
            Url = url + TestConfig.SponsorPage;
        }
    }
}

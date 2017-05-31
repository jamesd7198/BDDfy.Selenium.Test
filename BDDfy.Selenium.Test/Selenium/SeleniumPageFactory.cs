using System;

namespace BDDfy.Selenium.Test.Selenium
{
    public static class SeleniumPageFactory
    {
        public static TPage CreatePage<TPage>()
        {
            return (TPage) Activator.CreateInstance(
                typeof(TPage),
                ChromeBrowser.Driver,
                TestConfig.WebsiteBaseUrl);
        }
    }
}

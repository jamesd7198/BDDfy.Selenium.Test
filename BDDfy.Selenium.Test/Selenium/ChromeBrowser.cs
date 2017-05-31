using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDDfy.Selenium.Test.Selenium
{
    public class ChromeBrowser
    {
        public static IWebDriver Driver;

        public void Start()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            Driver = new ChromeDriver(options);
        }

        public void Stop()
        {
            Driver?.Quit();
        }
    }
}

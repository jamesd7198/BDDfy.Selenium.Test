using System.ComponentModel;
using System.Configuration;

namespace BDDfy.Selenium.Test
{
    public static class TestConfig
    {
        public static string WebsiteBaseUrl => GetAppSetting(nameof(WebsiteBaseUrl));
        public static string DonationPage => GetAppSetting(nameof(DonationPage));
        public static string ProjectsPage => GetAppSetting(nameof(ProjectsPage));
        public static string SolutionsPage => GetAppSetting(nameof(SolutionsPage));
        public static string SponsorPage => GetAppSetting(nameof(SponsorPage));
        public static string TheSpringPage => GetAppSetting(nameof(TheSpringPage));
        public static string CountryInfoPage => GetAppSetting(nameof(CountryInfoPage));
        public static string VolunteerPage => GetAppSetting(nameof(VolunteerPage));

        static string GetAppSetting(string name)
        {
            return GetAppSetting<string>(name);
        }

        static T GetAppSetting<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"{name} was not found or isn't configured in the configuration file.");
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(value);
        }
    }
}

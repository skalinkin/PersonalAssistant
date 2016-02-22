namespace PersonalAssistant.Craigslist
{
    internal class CraigslistConfiguration
    {
        static CraigslistConfiguration()
        {
        }

        public static CraigslistConfiguration Current { get; } = new CraigslistConfiguration();

        public string[] SiteUrls { get; } = {"https://sfbay.craigslist.org/"};
    }
}
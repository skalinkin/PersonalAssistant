using System.Collections.ObjectModel;

namespace PersonalAssistant.Craigslist
{
    internal class CraigslistConfiguration
    {
        public string GlobalRoot { get; set; } = "http://www.craigslist.org/about/sites";
        public Collection<string> RegionRoot { get; set; } = new Collection<string>();

        public CraigslistConfiguration()
        {
            RegionRoot.Add("http://sfbay.craigslist.org");
        }


    }
}
using System.Collections.Generic;
using System.Linq;

namespace PersonalAssistant.Craigslist
{
    internal class WebSiteFactory
    {
        public IEnumerable<WebSite> CreateAll()
        {
            return CraigslistConfiguration.Current.SiteUrls.Select(siteUrl => new WebSite(siteUrl));
        }
    }
}
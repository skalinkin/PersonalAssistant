namespace PersonalAssistant.Craigslist
{
    internal class WebSite
    {
        private readonly string jobSearchPrefix = "search/sof";
        private readonly string rootUrl;

        public WebSite(string rootUrl)
        {
            this.rootUrl = rootUrl;
        }

        public string RootUrl => rootUrl;

        public string GetJobsListingUrl()
        {
            var url = $"{rootUrl}{jobSearchPrefix}";
            return url;
        }
    }
}
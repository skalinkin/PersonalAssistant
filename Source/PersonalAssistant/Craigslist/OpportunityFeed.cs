using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using PersonalAssistant.Entities;

namespace PersonalAssistant.Craigslist
{
    internal class OpportunityFeed : IOpportunityFeed
    {
        private readonly OpportunityRepository repo;
        private readonly WebSiteFactory siteFactory;
        private readonly HtmlWeb webGet;

        public OpportunityFeed(OpportunityRepository repo, WebSiteFactory siteFactory)
        {
            this.repo = repo;
            this.siteFactory = siteFactory;
            webGet = new HtmlWeb();
        }

        public IEnumerable<Opportunity> FetchNew()
        {
            var sites = siteFactory.CreateAll();

            foreach (var webSite in sites)
            {
                var jobsDocument = webGet.Load(webSite.GetJobsListingUrl());
                var jobs = new SoftwareJobsList(jobsDocument);

                var links = jobs.GetLinks();
                var fullLinks = links.Select(link => $"{webSite.RootUrl}{link}");
                var newLinks = fullLinks.Where(link => !repo.ExistsWithOriginalSourceId(link));

                foreach (var link in newLinks)
                {
                    var post = new Post(webGet.Load(link));
                    var opportunity = PostToOpportunityConverter.Convert(post);
                    opportunity.OriginalSourceName = "craigslist";
                    opportunity.OriginalSourceId = link;
                    yield return opportunity;
                }
            }
        }
    }
}
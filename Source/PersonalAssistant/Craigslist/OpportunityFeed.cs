using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using HtmlAgilityPack;
using PersonalAssistant.Entities;

namespace PersonalAssistant.Craigslist
{
    internal class OpportunityFeed : IOpportunityFeed
    {
        private readonly OpportunityRepository repo;
        private readonly WebSiteFactory siteFactory;
        private readonly ILog logger;
        private readonly HtmlWeb webGet;

        public OpportunityFeed(OpportunityRepository repo, WebSiteFactory siteFactory, ILog logger)
        {
            this.repo = repo;
            this.siteFactory = siteFactory;
            this.logger = logger;
            webGet = new HtmlWeb();
        }

        public IEnumerable<Opportunity> FetchNew()
        {
            logger.Info("Starting Fetch");
            var sites = siteFactory.CreateAll().ToArray();

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
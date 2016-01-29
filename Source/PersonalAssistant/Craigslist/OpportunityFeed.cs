using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PersonalAssistant.Entities;

namespace PersonalAssistant.Craigslist
{
    internal class OpportunityFeed : IOpportunityFeed
    {
        private readonly IOpportunityRepository repo;
        private readonly WebDriver driver;

        public OpportunityFeed(IOpportunityRepository repo)
        {
            this.repo = repo;
            driver = new WebDriver();
        }

        public IEnumerable<Opportunity> FetchNew()
        {
            var document = driver.Postings();
            var webGet = new HtmlWeb();
            var list = new SoftwareJobsList(document);
            foreach (var link in list.GetLinks())
            {
                var opportunity = repo.FindByOriginalSourceId(link);
                if (opportunity != null)
                {
                    continue;
                }

                var htmlDocument = webGet.Load("http://sfbay.craigslist.org" + link);
                var post = new Post(htmlDocument);

                opportunity = new Opportunity();
                opportunity.Id = Guid.NewGuid();
                opportunity.Title = post.GetTitle();
                opportunity.Body = post.GetBody();
                opportunity.OriginalSourceId = link;
                opportunity.OriginalSourceName = "craigslist";

                yield return opportunity;
            }
        }
    }

    internal class WebDriver
    {
        private readonly HtmlWeb webGet = new HtmlWeb();

        public HtmlDocument Postings()
        {
            return webGet.Load("http://sfbay.craigslist.org/search/sof");
        }
    }
}
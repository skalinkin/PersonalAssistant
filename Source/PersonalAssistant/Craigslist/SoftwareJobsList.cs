using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace PersonalAssistant.Craigslist
{
    internal class SoftwareJobsList
    {
        private readonly HtmlDocument document;

        public SoftwareJobsList(HtmlDocument document)
        {
            this.document = document;
        }

        public string [] GetLinks()
        {
            var links = document.DocumentNode.SelectNodes("//a[@class='hdrlnk']");
            return links.Select(node => node.Attributes["href"].Value).ToArray();
        }
    }
}
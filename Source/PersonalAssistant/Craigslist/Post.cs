using HtmlAgilityPack;

namespace PersonalAssistant.Craigslist
{
    internal class Post
    {
        private readonly HtmlDocument document;

        public Post(HtmlDocument document)
        {
            this.document = document;
        }

        public string GetTitle()
        {
            return document.DocumentNode.SelectSingleNode("//span[@class='postingtitletext']").InnerText.Trim();
        }

        public string GetBody()
        {
            return document.DocumentNode.SelectSingleNode("//section[contains(@id,\"postingbody\")]").InnerText;
        }
    }
}
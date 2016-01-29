using System;
using LiteDB;

namespace PersonalAssistant.InMemmoryStore.POCOs
{
    public class OpportunityDocument
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string OriginalSourceName { get; set; }
        public string OriginalSourceId { get; set; }
    }
}
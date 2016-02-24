using System;
using LiteDB;
using PersonalAssistant.Entities;

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
        public Resolution Resolution { get; set; }
        public bool Read { get; set; }
        public float Probability { get; set; }
        public bool Trained { get; set; }
    }
}
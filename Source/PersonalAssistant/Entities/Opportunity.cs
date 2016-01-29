using System;
using System.Runtime.InteropServices;

namespace PersonalAssistant.Entities
{
    public class Opportunity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string OriginalSourceName { get; set; }
        public string OriginalSourceId { get; set; }
        public Resolution  Resolution { get; set; }
    }
}
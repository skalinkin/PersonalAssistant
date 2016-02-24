using CommandLine;

namespace Console.Options
{
    [Verb("show")]
    internal class ShowOptions
    {
        [Option('i',"interested")]
        public bool Interested { get; set; }
    }
}
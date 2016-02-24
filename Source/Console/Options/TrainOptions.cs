using CommandLine;

namespace Console.Options
{
    [Verb("train")]
    internal class TrainOptions
    {
        [Option('l', "list")]
        public bool ListCategories { get; set; }

        [Option('s', "samples")]
        public bool LoadSamples { get; set; }

        [Option('e', "execute")]
        public bool Execute { get; set; }

        [Option('h',"history")]
        public bool History { get; set; }
    }
}
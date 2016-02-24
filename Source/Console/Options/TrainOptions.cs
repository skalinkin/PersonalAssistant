using CommandLine;

namespace Console.Options
{
    [Verb("train")]
    internal class TrainOptions
    {
        [Option('l', "list")]
        public bool ListCategories { get; set; }

        [Option('s',"samples")]
        public bool LoadSamples { get; set; }
    }
}
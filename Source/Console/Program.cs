using System;
using Autofac;
using CommandLine;
using Console.Commands;
using Console.Options;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.InMemmoryStore;
using PersonalAssistant.MonkeyLearn;

namespace Console
{
    internal class Program
    {
        private const string ReadPrompt = "PA> ";

        private static void Main(string[] args)
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();
            Bootstrapper.Builder.RegisterModule<MonkeyLearnModule>();
            Bootstrapper.Builder.RegisterModule<ConsoleModule>();
            Bootstrapper.SetAutofacContainer();

            Parser.Default.ParseArguments<DiscoverOptions, TitleAnalisysOptions, DropDbOptions, ShowOptions, TrainOptions>(args)
                .WithParsed(opt =>
                {
                    var name = opt.GetType().Name.Substring(0, opt.GetType().Name.IndexOf("Options", StringComparison.Ordinal)).ToLower();
                    var command = Bootstrapper.Container.ResolveNamed<Command>(name);
                    command.Execute(opt);
                })
                .WithNotParsed(opt =>
                {
                    var command = Bootstrapper.Container.ResolveNamed<Command>("default");
                    command.Execute(opt);
                });
        }

       public static string ReadFromConsole(string promptMessage = "")
        {
            System.Console.Write(ReadPrompt + promptMessage);
            return System.Console.ReadLine();
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                System.Console.WriteLine(message);
            }
        }

        private static void WriteMessage(string message)
        {
            var defaultColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = defaultColor;
        }
    }
}
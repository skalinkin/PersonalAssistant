using System;
using System.IO;

namespace Console.Commands
{
    internal class DropDbCommand : Command
    {
        public override void Execute(object opt)
        {
            File.Delete("PersonalAssistant.db");
        }
    }
}
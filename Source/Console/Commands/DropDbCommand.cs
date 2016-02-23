using System;
using System.IO;

namespace Console.Commands
{
    internal class DropDbCommand : Command
    {
        public override void Execute()
        {
            File.Delete("PersonalAssistant.db");
        }
    }
}
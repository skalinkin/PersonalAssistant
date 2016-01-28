using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PersonalAssistant;
using PersonalAssistant.InMemmoryStore;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();

        }
    }
}
